using AutoMapper;
using NETSPARKER.Infrastructure.Interfaces;
using NETSPARKER.Infrastructure.Repositories;
using NETSPARKER.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using NETSPARKER.API.Models;
using NETSPARKER.Core.Entities;
using NETSPARKER.Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;


namespace NETSPARKER.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DownTimeController : Controller
    {
        private readonly UserService _userService;
        private readonly ProductService _productService;
        private readonly ProductNotificationService _productNotificationService;

        private readonly IMapper _mapper;

        public DownTimeController(
                                    UserService user,
                                    ProductService productService,
                                    ProductNotificationService productNotificationService,
                                    IMapper mapper)
        {
            _userService = user;
            _productService = productService;
            _productNotificationService = productNotificationService;
            _mapper = mapper;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(UserModel input)
        {
            ResultModel<UserModel> oModel = new Controllers.ResultModel<UserModel>
            {
                Data = null,
                Message = "Sistemde bir hata oluştu. ",
                Success = 1
            };

            try
            {
                var userData = _mapper.Map<UserEntity>(input);
                _userService.Create(userData);
                oModel.Data = _mapper.Map<UserModel>(_userService.Get(w => w.Email == input.Email).FirstOrDefault());
                oModel.Message = "Kayıt işlemi başarıyla gerçekleşti";
                oModel.Success = 0;
            }
            catch (Exception exp)
            {
                oModel.Message += " : " + exp.Message;
                throw;
            }


            return new ObjectResult(oModel);
        }

        [HttpGet("LoginUser")]
        public IActionResult LoginUser(string email, string pass)
        {
            ResultModel<UserModel> oModel = new Controllers.ResultModel<UserModel>
            {
                Data = null,
                Message = "Sistemde bir hata oluştu. ",
                Success = 1
            };

            try
            {
                var userData = _userService.Get(w => w.Email == email).FirstOrDefault();
                if (userData == null)
                {
                    // kullanıcıya mail adresinin sistemde olduğu bilgisini vermek bazı durumlarda yanlış olabilir. 
                    oModel.Message = "Sistemde belirtilen mail adresi kayıtlı değildir. Üye olun";

                }
                else
                {
                    if (pass == Cryptography.Decrypt(userData.PasswordHash, userData.SaltString))
                    {
                        oModel.Data = _mapper.Map<UserModel>(userData);
                        oModel.Message = "Login Başarılı";
                        oModel.Success = 0;
                    }
                    else
                    {
                        //aslında bu mesajla kullanıcıya bu mail adresinin aslında sistemde olduğu bilgisini veriyoruz :) bazı durumlarda güvenlik açığıdır ancak katmanlı kontrol etmeyi düşünebildiğimi görün istedim..
                        oModel.Message = "Şifreniz hatalı tekrar deneyin.";
                    }

                }
                return new ObjectResult(oModel);
            }
            catch (Exception exp)
            {
                oModel.Message += " : " + exp.Message;
                oModel.Success = -1;
                throw;
            }

        }

        [HttpPost("InsertProduct")]
        public IActionResult InsertProduct(ProductModel input)
        {
            ResultModel<ProductModel> oModel = new Controllers.ResultModel<ProductModel>
            {
                Data = null,
                Message = "Sistemde bir hata oluştu. ",
                Success = 1
            };

            try
            {
                var productData = _mapper.Map<ProductEntity>(input);
                if (productData.ID == 0)
                {
                    _productService.Create(productData);
                }
                else
                {
                    _productNotificationService.DeleteAll(_productNotificationService.Get(w => w.IDProduct == productData.ID));
                    _productService.Update(productData);
                }

                oModel.Message = "İşlemi başarıyla gerçekleşti";
                oModel.Success = 0;
            }
            catch (Exception exp)
            {
                oModel.Message += " : " + exp.Message;
                throw;
            }


            return new ObjectResult(oModel);
        }

        [HttpGet("GetProductById")]
        public IActionResult GetProductById(int id)
        {
            ResultModel<ProductModel> oModel = new ResultModel<ProductModel>
            {
                Data = null,
                Message = "Sistemde bir hata oluştu. ",
                Success = 0
            };

            try
            {
                var productData = _productService.GetById(id);
                if (productData != null && productData.ID > 0)
                {
                    var pNotification = _productNotificationService.Get(q => q.IDProduct == productData.ID);
                    productData.ProductNotification = _mapper.Map<List<ProductNotificationEntity>>(pNotification);
                }

                oModel.Data = _mapper.Map<ProductModel>(productData);

            }
            catch (Exception exp)
            {
                oModel.Message += " : " + exp.Message;
                oModel.Success = -1;
                throw;
            }


            return new ObjectResult(oModel);
        }

        [HttpGet("GetProductList")]
        public IActionResult GetProductList(int id)
        {
            ResultModel<List<ProductModel>> oModel = new ResultModel<List<ProductModel>>
            {
                Data = null,
                Message = "Sistemde bir hata oluştu. ",
                Success = 0
            };

            try
            {
                var productDataList = _productService.Get(q => q.IsActive == "E");


                if (productDataList != null && productDataList.Count() > 0)
                {
                    foreach (var item in productDataList)
                    {
                        var pNotification = _productNotificationService.Get(q => q.IDProduct == item.ID && q.IsActive == "E");
                        item.ProductNotification = _mapper.Map<List<ProductNotificationEntity>>(pNotification);
                    }

                }

                oModel.Data = _mapper.Map<List<ProductModel>>(productDataList);
            }
            catch (Exception exp)
            {
                oModel.Message += " : " + exp.Message;
                oModel.Success = -1;
                throw;
            }


            return new ObjectResult(oModel);
        }

        [HttpGet("DeleteProduct")]
        public IActionResult DeleteProduct(int id)
        {
            ResultModel<int> oModel = new Controllers.ResultModel<int>
            {
                Data = id,
                Message = "Sistemde bir hata oluştu. ",
                Success = 1
            };

            try
            {
                if (id > 0)
                {

                    _productService.SoftDelete(id);
                    _productNotificationService.SoftDeleteAll(_productNotificationService.Get(q => q.IDProduct == id));
                }

                oModel.Message = "İşlemi başarıyla gerçekleşti";
                oModel.Success = 0;
            }
            catch (Exception exp)
            {
                oModel.Message += " : " + exp.Message;
                throw;
            }


            return new ObjectResult(oModel);
        }
    }
}