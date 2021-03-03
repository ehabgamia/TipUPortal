using System.Collections.Generic;
using MCV.Portal.Authorization.Delegation;
using MCV.Portal.Authorization.Users.Delegation.Dto;

namespace MCV.Portal.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }
        
        public List<UserDelegationDto> UserDelegations { get; set; }
    }
}
