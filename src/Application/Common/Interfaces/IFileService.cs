
using CookingMasterApi.Domain.Entities;

namespace CookingMasterApi.Application.Common.Interfaces;
public interface IFileService
{
    public Task SaveFileStream(FileDetails fileDetails, Stream fileStream);
    public Task<Stream> ReadFileStream(Guid FileUid);
}
