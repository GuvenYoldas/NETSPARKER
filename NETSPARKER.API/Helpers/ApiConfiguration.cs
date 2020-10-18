using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace NETSPARKER.API.Helpers
{
    public class ApiConfiguration
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
   .SetBasePath(Directory.GetCurrentDirectory())
   .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
   .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
   .Build();

        #region Url

        private string m_SiteUrl = string.Empty;
        public string SiteUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_SiteUrl))
                {
                    if (Configuration["AppSettings:SiteUrl"] == null)
                    {
                        throw new Exception("SiteUrl key not specified in ApiConfiguration Section in appsettings.json! Please Check That Key!");
                    }
                    else
                    {
                        m_SiteUrl = Configuration["AppSettings:SiteUrl"].ToString();
                    }
                }
                return m_SiteUrl;
            }
        }

        private string m_RepoUrl = string.Empty;
        public string RepoUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoUrl))
                {
                    m_RepoUrl = SiteUrl + "Repo" + "/";
                }
                return m_RepoUrl;
            }
        }

        private string m_RepoUrl_OperatorProfilePictureUrl = string.Empty;
        public string RepoUrl_OperatorProfilePictureUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoUrl_OperatorProfilePictureUrl))
                {
                    m_RepoUrl_OperatorProfilePictureUrl = RepoUrl + "OperatorProfilePicture" + "/";
                }
                return m_RepoUrl_OperatorProfilePictureUrl;
            }
        }

        private string m_NoProfilePictureUrl = string.Empty;
        public string NoProfilePictureUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_NoProfilePictureUrl))
                {
                    m_NoProfilePictureUrl = SiteUrl + "assets/dist/images/dummy450x450.jpg";
                }
                return m_NoProfilePictureUrl;
            }
        }

        private string m_NoPhotoMachineUrl = string.Empty;
        public string NoPhotoMachineUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_NoPhotoMachineUrl))
                {
                    m_NoPhotoMachineUrl = SiteUrl + "assets/dist/images/dummyPhotoMachine.jpg";
                }
                return m_NoPhotoMachineUrl;
            }
        }
        private string m_RepoUrl_CompanyPictureUrl = string.Empty;
        public string RepoUrl_CompanyPictureUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoUrl_CompanyPictureUrl))
                {
                    m_RepoUrl_CompanyPictureUrl = RepoUrl + "CompanyPicture" + "/";
                }
                return m_RepoUrl_CompanyPictureUrl;
            }
        }

        private string m_RepoUrl_CompanyProductCatalogUrl = string.Empty;
        public string RepoUrl_CompanyProductCatalogUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoUrl_CompanyProductCatalogUrl))
                {
                    m_RepoUrl_CompanyProductCatalogUrl = RepoUrl + "ProductCatalog" + "/";
                }
                return m_RepoUrl_CompanyProductCatalogUrl;
            }
        }

        private string m_RepoUrl_CompanyLogoUrl = string.Empty;
        public string RepoUrl_CompanyLogoUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoUrl_CompanyLogoUrl))
                {
                    m_RepoUrl_CompanyLogoUrl = RepoUrl + "CompanyLogo" + "/";
                }
                return m_RepoUrl_CompanyLogoUrl;
            }
        }

        private string m_RepoUrl_CompanyCertificateUrl = string.Empty;
        public string RepoUrl_CompanyCertificateUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoUrl_CompanyCertificateUrl))
                {
                    m_RepoUrl_CompanyCertificateUrl = RepoUrl + "CompanyCertificate" + "/";
                }
                return m_RepoUrl_CompanyCertificateUrl;
            }
        }

        private string m_RepoUrl_OutsourceAssignWorkDocumentUrl = string.Empty;
        public string RepoUrl_OutsourceAssignWorkDocumentUrl
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoUrl_OutsourceAssignWorkDocumentUrl))
                {
                    m_RepoUrl_OutsourceAssignWorkDocumentUrl = RepoUrl + "OutsourceAssignWorkDocument" + "/";
                }
                return m_RepoUrl_OutsourceAssignWorkDocumentUrl;
            }
        }
        #endregion

        #region PATH

        private string m_SitePath = string.Empty;
        public string SitePath
        {
            get
            {
                if (String.IsNullOrEmpty(m_SitePath))
                {
                    if (Configuration["AppSettings:SitePath"] == null)
                    {
                        throw new Exception("SitePath key not specified in ApiConfiguration Section in appsettings.json! Please Check That Key!");
                    }
                    else
                    {
                        m_SitePath = Configuration["AppSettings:SitePath"].ToString();
                    }
                }
                return m_SitePath;
            }
        }

        private string m_RootPath = string.Empty;
        public string RootPath
        {
            get
            {
                if (String.IsNullOrEmpty(m_RootPath))
                {
                    m_RootPath = SitePath + "wwwroot" + "\\";
                }
                return m_RootPath;
            }
        }

        private string m_RepoPath = string.Empty;
        public string RepoPath
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoPath))
                {
                    m_RepoPath = RootPath + "Repo" + "\\";
                }
                return m_RepoPath;
            }
        }

        private string m_RepoPath_OperatorProfilePicturePath = string.Empty;
        public string RepoPath_OperatorProfilePicturePath
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoPath_OperatorProfilePicturePath))
                {
                    m_RepoPath_OperatorProfilePicturePath = RepoPath + "OperatorProfilePicture" + "\\";
                }
                return m_RepoPath_OperatorProfilePicturePath;
            }
        }

        private string m_NoProfilePicturePath = string.Empty;
        public string NoProfilePicturePath
        {
            get
            {
                if (String.IsNullOrEmpty(m_NoProfilePicturePath))
                {
                    m_NoProfilePicturePath = m_NoProfilePicturePath + "assets\\dist\\images\\dummy450x450.jpg";
                }
                return m_NoProfilePicturePath;
            }
        }
        #endregion

        private string m_ImageAllowedImageFormats = string.Empty;
        public string ImageAllowedImageFormats
        {
            get
            {
                if (String.IsNullOrEmpty(m_ImageAllowedImageFormats))
                {
                    if (Configuration["AppSettings:ImageAllowedImageFormats"] == null)
                    {
                        throw new Exception("ImageAllowedImageFormats key not specified in ApiConfiguration Section in appsettings.json! Please Check That Key!");
                    }
                    else
                    {
                        m_ImageAllowedImageFormats = Configuration["AppSettings:ImageAllowedImageFormats"].ToString();
                    }
                }
                return m_ImageAllowedImageFormats;
            }
        }

        private int m_ImageMaxSize = -1;
        public int ImageMaxSize
        {
            get
            {
                if (m_ImageMaxSize < 0)
                {
                    if (Configuration["AppSettings:ImageMaxSize"] == null)
                    {
                        throw new Exception("ImageMaxSize key not specified in ApiConfiguration Section in appsettings.json! Please Check That Key!");
                    }
                    else
                    {
                        string strTemp = Configuration["AppSettings:ImageMaxSize"].ToString();
                        if (!Int32.TryParse(strTemp, out m_ImageMaxSize))
                        {
                            m_ImageMaxSize = -1;
                            throw new Exception("MaxImageSize key value can not be converted to integer in Web.config! Please Check That Key!");
                        }
                    }
                }
                return m_ImageMaxSize;
            }
        }

        private int m_DocumentMaxSize = -1;
        public int DocumentMaxSize
        {
            get
            {
                if (m_DocumentMaxSize < 0)
                {
                    if (Configuration["AppSettings:DocumentMaxSize"] == null)
                    {
                        throw new Exception("DocumentMaxSize key not specified in ApiConfiguration Section in appsettings.json! Please Check That Key!");
                    }
                    else
                    {
                        string strTemp = Configuration["AppSettings:DocumentMaxSize"].ToString();
                        if (!Int32.TryParse(strTemp, out m_DocumentMaxSize))
                        {
                            m_DocumentMaxSize = -1;
                            throw new Exception("DocumentMaxSize key value can not be converted to integer in Web.config! Please Check That Key!");
                        }
                    }
                }
                return m_DocumentMaxSize;
            }
        }


        private string m_DocumentAllowedFileFormats = string.Empty;
        public string DocumentAllowedFileFormats
        {
            get
            {
                if (String.IsNullOrEmpty(m_DocumentAllowedFileFormats))
                {
                    if (Configuration["AppSettings:DocumentAllowedFileFormats"] == null)
                    {
                        throw new Exception("DocumentAllowedFileFormats key not specified in ApiConfiguration Section in appsettings.json! Please Check That Key!");
                    }
                    else
                    {
                        m_DocumentAllowedFileFormats = Configuration["AppSettings:DocumentAllowedFileFormats"].ToString();
                    }
                }
                return m_DocumentAllowedFileFormats;
            }
        }

        private string m_RepoPath_CompanyPicturePath = string.Empty;
        public string RepoPath_CompanyPicturePath
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoPath_CompanyPicturePath))
                {
                    m_RepoPath_CompanyPicturePath = RepoPath + "CompanyPicture" + "\\";
                }
                return m_RepoPath_CompanyPicturePath;
            }
        }

        private string m_RepoPath_CompanyLogoPath = string.Empty;
        public string RepoPath_CompanyLogoPath
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoPath_CompanyLogoPath))
                {
                    m_RepoPath_CompanyLogoPath = RepoPath + "CompanyLogo" + "\\";
                }
                return m_RepoPath_CompanyLogoPath;
            }
        }

        private string m_RepoPath_ProductCatalogPath = string.Empty;
        public string RepoPath_CompanyProductCatalogPath
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoPath_ProductCatalogPath))
                {
                    m_RepoPath_ProductCatalogPath = RepoPath + "ProductCatalog" + "\\";
                }
                return m_RepoPath_ProductCatalogPath;
            }
        }

        private string m_RepoPath_CompanyCertificatePath = string.Empty;
        public string RepoPath_CompanyCertificatePath
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoPath_CompanyCertificatePath))
                {
                    m_RepoPath_CompanyCertificatePath = RepoPath + "CompanyCertificate" + "\\";
                }
                return m_RepoPath_CompanyCertificatePath;
            }
        }

        private string m_RepoPath_OutsourceAssignWorkDocumentPath = string.Empty;

        public string RepoPath_OutsourceAssignWorkDocumentPath
        {
            get
            {
                if (String.IsNullOrEmpty(m_RepoPath_OutsourceAssignWorkDocumentPath))
                {
                    m_RepoPath_OutsourceAssignWorkDocumentPath = RepoPath + "OutsourceAssignWorkDocument" + "\\";
                }
                return m_RepoPath_OutsourceAssignWorkDocumentPath;
            }
        }
    }
}
