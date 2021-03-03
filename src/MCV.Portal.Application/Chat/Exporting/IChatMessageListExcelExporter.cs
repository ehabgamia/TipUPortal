using System.Collections.Generic;
using Abp;
using MCV.Portal.Chat.Dto;
using MCV.Portal.Dto;

namespace MCV.Portal.Chat.Exporting
{
    public interface IChatMessageListExcelExporter
    {
        FileDto ExportToFile(UserIdentifier user, List<ChatMessageExportDto> messages);
    }
}
