using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Net.Mail.Smtp;
using Abp.Runtime.Session;
using MCV.Portal.ITService.Dto;
using MCV.Portal.Net.Emailing;
using MCV.Portal.Notifications;
using MCV.Portal.Subject;
using MCV.Portal.Subject.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCV.Portal.Subjects
{
    public class SubjectAppService : PortalAppServiceBase, ISubjectAppService
    {
        private readonly IRepository<Subject> _subjectRepository;
        private readonly ISmtpEmailSender _smtpEmailSender;
        private readonly IEmailTemplateProvider _emailTemplateProvider;
        private readonly IAppNotifier _iappnotifier;

        public SubjectAppService(IRepository<Subject> SubjectRepository, ISmtpEmailSender SmtpEmailSender, IAppNotifier Iappnotifier,
            IEmailTemplateProvider EmailTemplateProvider)
        {
            _subjectRepository = SubjectRepository;
            _smtpEmailSender = SmtpEmailSender;
            _iappnotifier = Iappnotifier;
            _emailTemplateProvider = EmailTemplateProvider;
        }

        public async Task CreateSubject(CreateSubjectInput input)
        {
            var subject = ObjectMapper.Map<Subjects.Subject>(input);
            await _subjectRepository.InsertAsync(subject);
            int usrId = (int)AbpSession.GetUserId();
            var user = await UserManager.GetUserByIdAsync(usrId);
            await _iappnotifier.NewSubjectNotifiy(user);
        }

        public async Task DeleteSubject(EntityDto input)
        {
            await _subjectRepository.DeleteAsync(input.Id);
        }

        public async Task<ListResultDto<SubjectListDto>> GetSubject(GetSubjectInput input)
        {
            try
            {
                var subject = await _subjectRepository
                  .GetAll()
                  .OrderBy(p => p.Id)
                  .ThenBy(p => p.Id)
                  .ToListAsync();

                var subjListDtos = ObjectMapper.Map<List<SubjectListDto>>(subject);

                return  new ListResultDto<SubjectListDto>(ObjectMapper.Map<List<SubjectListDto>>(subjListDtos));
            }
            catch(Exception ex)
            {
                Logger.Error("GetSubject", ex);
            }
            return null;
        }

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
    }
    
}
