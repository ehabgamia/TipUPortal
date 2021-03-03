using Abp.Application.Services.Dto;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.Net.Mail;
using Abp.Notifications;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper.Configuration;
using MailKit;
using MailKit.Security;
using MCV.Portal.Authorization.Users;
using MCV.Portal.Authorization.Users.Dto;
using MCV.Portal.Category;
using MCV.Portal.ITService.Dto;
using MCV.Portal.Location;
using MCV.Portal.Notifications;
using MCV.Portal.SubCategory;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using Twilio.Http;
using MCV.Portal.Net.Emailing;
using MCV.Portal.Problem;

namespace MCV.Portal.ITService
{

    public class CallAppService :  PortalAppServiceBase, ICallsAppService
    { 
        private readonly IRepository<Calls> _callsRepository;
        private readonly IEnumerable<User> _usersRepository;
        private readonly UserAppService _userRepository;
        private readonly IRepository<Categories> _categoryRepository;
        private readonly IRepository<SubCategoryType> _subCategoryRepository;
        private readonly IRepository<LocationType> _locationRepository;
        private readonly IUserNotificationManager _userNotificationManager;
        public List<string> _uploadPathFile = new List<string>();
        public EmailSenderBase _EmailSenderBase;
        public readonly IAppNotifier _appNotifier;
        private readonly IEmailSender _emailSender;
        private readonly IEmailTemplateProvider _emailTemplateProvider;
        private readonly Abp.Net.Mail.Smtp.SmtpEmailSender _smtpEmailSender;
        private readonly IRepository<Branches.Branche> _branchesRepository;
        private readonly IRepository<CategoryService.CategoryServe> _categoryServicePropblemRepository;
        private readonly IRepository<CallProblem> _callPropblemRepository;

        //List<string> _uploadPathFile = new List<string>();
        //private readonly GetUsers _getUsers;

        public enum RequestDetails
        {
            Approve = 1,
            Reject = 0
        }

        public CallAppService(IRepository<Calls> CallsRepository, UserAppService UserRepository,
            IRepository<Categories> CategoryRepository, IRepository<LocationType> LocationRepository,
            IRepository<SubCategoryType> SubCategoryRepository, IUserNotificationManager userNotificationManager,
           IAppNotifier AppNotifier, IEmailSender emailSender, Net.Emailing.IEmailTemplateProvider EmailTemplateProvider,
           Abp.Net.Mail.Smtp.SmtpEmailSender SmtpEmailSender, IEnumerable<User> UsersRepository,
           IRepository<Branches.Branche> BranchesRepository, IRepository<CallProblem> CallPropblemRepository, 
           IRepository<CategoryService.CategoryServe> CategoryServicePropblemRepository)
        {
            _callsRepository = CallsRepository;
            _userRepository = UserRepository;
            _categoryRepository = CategoryRepository;
            _locationRepository = LocationRepository;
            _subCategoryRepository = SubCategoryRepository;
            _userNotificationManager = userNotificationManager;
            _appNotifier = AppNotifier;
            _emailSender = emailSender;
            _emailTemplateProvider = EmailTemplateProvider;
            _smtpEmailSender = SmtpEmailSender;
            _usersRepository = UsersRepository;
            _branchesRepository = BranchesRepository;
            _callPropblemRepository = CallPropblemRepository;
            _categoryServicePropblemRepository = CategoryServicePropblemRepository;
        }

        #region HttpGet
        public ListResultDto<GetADUsers> GetADUsers()
        {
            try
            {
                var users = UserManager.Users;
                return new ListResultDto<GetADUsers>(ObjectMapper.Map<List<GetADUsers>>(users));
            }
            catch (Exception ex)
            {
                Logger.Error("GetUsers", ex);
            }
            return null;
        }
        public ListResultDto<GetReporter> GetReporter()
        {
            try
            {
                //Get Current User By Session
                int usrId = (int)AbpSession.GetUserId();
                var user =  UserManager.GetUserByIdAsync(usrId);
                var users = UserManager.Users;
                var usr = users.Where(s => s.UserName == user.Result.UserName);
                
                return new ListResultDto<GetReporter>(ObjectMapper.Map<List<GetReporter>>(usr));
            }
            catch (Exception ex)
            {
                Logger.Error("GetReporter", ex);
            }
            return null;
        }
        public ListResultDto<GetUsers> GetCallUsers()
        {
            try
            {
                var AllCalls = _callsRepository//.GetAllIncluding(a => a.UserName)
                                               //.GetAll().Select(s => new GetUsers { name = s.UserName, user_id = s.Id })
               .GetAll()
               //.WhereIf(
               //    !input.Id.IsNullOrEmpty(),
               //    p => p.UserName.Contains(input.)
               //)
               //.OrderBy(p => p.Id)
               //.FirstOrDefault();
               .ToList();
                //return AllCalls;
                return new ListResultDto<GetUsers>(ObjectMapper.Map<List<GetUsers>>(AllCalls));
            }
            catch (Exception ex)
            {
                Logger.Error("GetUsers", ex);
            }
            return null;
        }
        public ListResultDto<CallsListDto> GetCalls(GetCallsInput input)
        {
            try
            {
                // Not Appoved
                var AllCalls = _callsRepository
               .GetAll()
               .Where(t=>t.Status == (int)RequestDetails.Reject & t.IsRejected == 0 )
               .ToList();

                #region
                //AllCalls.ForEach(t =>
                //{
                //    CallsListDto callsList = new CallsListDto()
                //    {
                //        UserName = t.UserName,
                //        Reporter = t.Reporter,
                //        PCNo = t.PCNo,
                //        LocationTypeID = t.LocationTypeID,
                //        Description = t.Description,
                //        Subject = t.Subject,
                //        Date = t.Date,
                //        CreationTime = t.CreationTime,
                //        CreatorUserId = t.CreatorUserId,
                //        CategoryId = t.CategoryId,
                //        SubCategoryId = t.SubCategoryId,
                //        Status = "Approved",
                //    };
                //});
                #endregion  

                return new ListResultDto<CallsListDto>(ObjectMapper.Map<List<CallsListDto>>(AllCalls));
            } 
            catch (Exception ex)
            {
                Logger.Error("GetCalls", ex);
            }
            return null;
        }
        public ListResultDto<CallsListDto> GetCallsApproved(GetCallsInput input)
        {
            try
            {
                var AllCalls = _callsRepository
               .GetAll()
               .Where(t => t.Status == (int)RequestDetails.Approve & t.IsRejected == 0 )
               .ToList();

                return new ListResultDto<CallsListDto>(ObjectMapper.Map<List<CallsListDto>>(AllCalls));
            }
            catch (Exception ex)
            {
                Logger.Error("GetCalls", ex);
            }
            return null;
        }
        public ListResultDto<CallsListDto> GetCallsById(GetCallsByIdInput input)
        {
            try
            {
                var AllCalls = _callsRepository
               .GetAll()
               .Where(t=>t.Id == input.Id)
               .ToList();

                return new ListResultDto<CallsListDto>(ObjectMapper.Map<List<CallsListDto>>(AllCalls));
            }
            catch (Exception ex)
            {
                Logger.Error("GetCalls", ex);
            }
            return null;
        }
        public ListResultDto<GetCategoriesInput> GetCategories()
        {
            try
            {
                var AllCategories = _categoryRepository
               .GetAll()
               .ToList();
                return new ListResultDto<GetCategoriesInput>(ObjectMapper.Map<List<GetCategoriesInput>>(AllCategories));
            }
            catch (Exception ex)
            {
                Logger.Error("GetCategories", ex);
            }
            return null;
        }
        public ListResultDto<GetSubCategoriesInput> GetSubCategories(SubCategorieInput input)
        {
            try
            {
                var AllCategories = _subCategoryRepository
               .GetAll()
               .Where(g => g.CategoryId == input.CategoryId)
               .ToList();

                return new ListResultDto<GetSubCategoriesInput>(ObjectMapper.Map<List<GetSubCategoriesInput>>(AllCategories));
            }
            catch (Exception ex)
            {
                Logger.Error("GetCategories", ex);
            }
            return null;
        }
        public ListResultDto<GetLocationInput> GetLocations()
        {
            try
            {
                var AllLocations = _locationRepository
               .GetAll()
               .ToList();

                return new ListResultDto<GetLocationInput>(ObjectMapper.Map<List<GetLocationInput>>(AllLocations));
            }
            catch (Exception ex)
            {
                Logger.Error("GetLocations", ex);
            }
            return null;
        }
        public ListResultDto<GetBranches> GetBranches()
        {
            try
            {
               var AllBranches = _branchesRepository.GetAll()
               .ToList();
                return new ListResultDto<GetBranches>(ObjectMapper.Map<List<GetBranches>>(AllBranches));
            }
            catch (Exception ex)
            {
                Logger.Error("GetBranches", ex);
            }
            return null;
        }

        public ListResultDto<GetBranches> GetBranchesById(Int64 Id)
        {
            try
            {
                var AllBranches = _branchesRepository.GetAll().Where(t=>t.Id == Id)
                .ToList();
                return new ListResultDto<GetBranches>(ObjectMapper.Map<List<GetBranches>>(AllBranches));
            }
            catch (Exception ex)
            {
                Logger.Error("GetBranches", ex);
            }
            return null;
        }

        public ListResultDto<GetProbCat> GetProblemCat()
        {
            try
            {
                var AllPropCat = _categoryServicePropblemRepository
                .GetAll()
                .ToList();
                
                return new ListResultDto<GetProbCat>(ObjectMapper.Map<List<GetProbCat>>(AllPropCat));
            }
            catch (Exception ex)
            {
                Logger.Error("GetProblemCat", ex);
            }
            return null;
        }

        public ListResultDto<GetProbCat> GetProblemCatbyId(GetProblemCat Input)
        {
            try
            {
                var AllPropCat = _categoryServicePropblemRepository
                .GetAll().Where(t=>t.Id == Input.CATEGORYID)
                .ToList();

                return new ListResultDto<GetProbCat>(ObjectMapper.Map<List<GetProbCat>>(AllPropCat));
            }
            catch (Exception ex)
            {
                Logger.Error("GetProblemCat", ex);
            }
            return null;
        }

        public ListResultDto<GetSubProbCat> GetSubProblemCat(GetProblemCat Input)
        {
            try
            {
                var AllPropCat = _callPropblemRepository.GetAll().Where(g => g.CATEGORYID == Input.CATEGORYID)
                .ToList();
                return new ListResultDto<GetSubProbCat>(ObjectMapper.Map<List<GetSubProbCat>>(AllPropCat));
            }
            catch (Exception ex)
            {
                Logger.Error("GetProblemCat", ex);
            }
            return null;
        }
        #endregion

        #region HttpPost
        public async Task CreatCategory(CreateCategory input)
        {
            try
            {
                Categories cat = new Categories()
                {
                    CategoryName = input.CategoryName,
                    CategoryId   = input.CategoryId
                    //SubCtegoryName = input.SubCtegoryName
                };
                await _categoryRepository.InsertAsync(cat);
            }
            catch (Exception ex)
            {
                Logger.Error("CreatCategory", ex);
            }
        }
        public async Task CreatNewRequestService(CreateNewRequest input)
        {
            try
            {
                int usrId = (int)AbpSession.GetUserId();
                var user = await UserManager.GetUserByIdAsync(usrId);
                string userName = string.Empty;
                long userId = 0;
               
                if (input.UploadPathFile.IsNullOrEmpty())
                {
                    input.UploadPathFile = string.Empty;
                }
                else
                {
                    var folderName = Path.Combine("Resources", "Uploads");
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    input.UploadPathFile = Path.Combine(filePath, input.UploadPathFile);
                }

                Calls calls = new Calls
                {
                    Reporter = user.UserName,
                    UserName = input.UserName,
                    Description = input.Description,
                    Date = input.Date,
                    CategoryId = input.CategoryId,
                    SubCategoryId = input.SubCategoryId,
                    Subject = input.Subject,
                    LocationTypeID = input.LocationTypeID,
                    PCNo = input.PCNo,
                    UploadPathFile = input.UploadPathFile
                };

                var callId = await _callsRepository.InsertAsync(calls);

                userId = UserManager.Users.ToList().Where(t => t.UserName == input.UserName).Select(r => r.Id).FirstOrDefault();
                var userNotify = await UserManager.GetUserByIdAsync(userId);
                await _appNotifier.ITServiceNotification(userNotify,1);

                string Url = "https://localhost:44301/api/services/app/Call/GetApproval?callId=" + callId.Id;
                
                var emailTemplate = new System.Text.StringBuilder(_emailTemplateProvider.GetDefaultNotitificationTemplate(userNotify.TenantId, "Dear ,"+  userNotify.UserName, 
                    "Message:", "Please Aprrove on the Request",Url,false));

                using (var smtpClient = _smtpEmailSender.BuildClient())
                {
                    var mail = new MailMessage();
                    mail.From = new MailAddress(userNotify.EmailAddress);
                    mail.To.Add(userNotify.EmailAddress);
                    mail.Body = emailTemplate.ToString();
                    mail.Subject = "MCV Portal Notification";
                    mail.IsBodyHtml = true;
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;

                    await smtpClient.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("CreatNewRequestService", ex);
            }
        }

        [HttpGet]
        public void GetApproval(int callId)
        {
            string userName = string.Empty;
            long userId = 0;

            var AllCalls = _callsRepository
              .GetAll()
              .Where(t => t.Id == callId)
              .ToList();

            AllCalls.ForEach(e =>
            {
                e.Status = (int)RequestDetails.Approve;
                userName = e.UserName;
                userId = UserManager.Users.ToList().Where(t => t.UserName == e.UserName).Select(r => r.Id).FirstOrDefault();
            });

            _callsRepository.UpdateAsync(AllCalls.FirstOrDefault());

            //return callId;
        }
        public async Task CreateCalls(CreateCallsInput input)
        {
            try
            {
                //var Calls = ObjectMapper.Map<Calls>(input);
                int usrId = (int)AbpSession.GetUserId();
                var user = await UserManager.GetUserByIdAsync(usrId);
                //var users = GetUsers();

                Calls call = new Calls
                {
                    Reporter = user.UserName,
                    UserName = user.UserName,
                    //Location = input.Location,
                    Description = input.Description,
                    //Problem = input.Problem,
                    //CostCenter = input.CostCenter,
                    PCNo = input.PCNo,
                    //ExtentionNo  = input.ExtentionNo,
                };
                await _callsRepository.InsertAsync(call);
            }
            catch (Exception ex)
            {
                Logger.Error("CreateCalls", ex);
            }

        }
        public async Task<string> UploadFiles(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new UserFriendlyException("Please select File");

            var folderName = Path.Combine("Resources", "Uploads");
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            int userId = (int)AbpSession.GetUserId();
            var uniqueFileName = $"{userId}_" + file.FileName ;
            var dbPath = Path.Combine(folderName, uniqueFileName);
            _uploadPathFile.Add(dbPath);

            using (var fileStream = new FileStream(Path.Combine(filePath, uniqueFileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return dbPath;
        }
        public async Task ApprReqServ(int Id)
        {
            try
            {
                int usrId = (int)AbpSession.GetUserId();
                var user = await UserManager.GetUserByIdAsync(usrId);
                string userName = string.Empty;
                long userId = 0;
                
                var AllCalls = _callsRepository
               .GetAll()
               .Where(t => t.Id == Id)
               .ToList();

                var allUsrs = UserManager.Users.ToList();

                AllCalls.ForEach(e =>
                {
                    e.Status = (int)RequestDetails.Approve;
                    userName = e.UserName;
                    userId = UserManager.Users.ToList().Where(t => t.UserName == e.UserName ).Select(r => r.Id).FirstOrDefault();
                });
                
                await _callsRepository.UpdateAsync(AllCalls.FirstOrDefault());
                
                var userNotify = await UserManager.GetUserByIdAsync(userId);
                await _appNotifier.ITServiceNotification(userNotify,2);

                //var emailTemplate = new System.Text.StringBuilder(_emailTemplateProvider.GetConfirmationNotitificationTemplate(userNotify.TenantId, "Dear ," + userNotify.UserName,
                //    "Message:", "Your Request has been Approved"));

                using (var smtpClient = _smtpEmailSender.BuildClient())
                {
                    var mail = new MailMessage();
                    mail.From = new MailAddress(userNotify.EmailAddress);
                    mail.To.Add(userNotify.EmailAddress);
                    mail.Body = "Dear ," + userNotify.UserName + " Your Request has been Approved";
                    mail.Subject = "MCV Portal Notification";
                    mail.IsBodyHtml = true;
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;

                    await smtpClient.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("ApprReqServ", ex);
            }
        }
        public async Task RejReqServ(int Id)
        {
            try
            {
                int usrId = (int)AbpSession.GetUserId();
                var user = await UserManager.GetUserByIdAsync(usrId);
                string userName = string.Empty;
                long userId = 0;

                var AllCalls = _callsRepository
               .GetAll()
               .Where(t => t.Id == Id)
               .ToList();

                var allUsrs = UserManager.Users.ToList();

                AllCalls.ForEach(e =>
                {
                    e.Status = (int)RequestDetails.Reject;
                    e.IsRejected = 1;
                    userName = e.UserName;
                    userId = UserManager.Users.ToList().Where(t => t.UserName == e.UserName).Select(r => r.Id).FirstOrDefault();
                });

                await _callsRepository.UpdateAsync(AllCalls.FirstOrDefault());

                var userNotify = await UserManager.GetUserByIdAsync(userId);
                await _appNotifier.ITServiceNotification(userNotify,3);

                //var emailTemplate = new System.Text.StringBuilder(_emailTemplateProvider.GetConfirmationNotitificationTemplate(userNotify.TenantId, "Dear ," + userNotify.UserName,
                //    "Message:", "Your Request has been Rejected"));

                using (var smtpClient = _smtpEmailSender.BuildClient())
                {
                    var mail = new MailMessage();
                    mail.From = new MailAddress(userNotify.EmailAddress);
                    mail.To.Add(userNotify.EmailAddress);
                    mail.Body = "Dear ," + userNotify.UserName + " Your Request has been Rejected";
                    mail.Subject = "MCV Portal Notification";
                    mail.IsBodyHtml = true;
                    mail.BodyEncoding = System.Text.Encoding.UTF8;
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;

                    await smtpClient.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("RejReqServ", ex);
            }
        }
        public async Task SendMail(MailRequest email)
        {
            try
            {
                var client = new SmtpClient(AppConsts.Smtp, AppConsts.Port);
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;

                client.Credentials = new System.Net.NetworkCredential(AppConsts.UserName, AppConsts.Password);

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(AppConsts.Address);

                mailMessage.To.Add(email.ToEmail);

                if (!string.IsNullOrEmpty(email.CCEmail))
                {
                    mailMessage.CC.Add(email.CCEmail);
                }

                mailMessage.Body = email.Body;

                mailMessage.Subject = email.Subject;

                mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
                mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

                await client.SendMailAsync(mailMessage);
            }
            catch(Exception ex)
            {
                Logger.Error("CreatNewRequestService", ex);
            }
            
        }

        #endregion

        #region HttpDelete
        public async Task DeleteCalls(EntityDto input)
        {
            try
            {
                await _callsRepository.DeleteAsync(input.Id);
            }
            catch (Exception ex)
            {
                Logger.Error("DeleteCalls", ex);
            }
        }
        #endregion
    }
}
