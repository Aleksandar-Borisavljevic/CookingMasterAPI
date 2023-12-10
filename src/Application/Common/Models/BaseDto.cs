using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CookingMasterApi.Application.Common.Models;
public class BaseDto
{
    public DateTime Created { get; set; }
    public string CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string LastModifiedBy { get; set; }
    public DateTime? Deleted { get; set; }
    public string DeletedBy { get; set; }
}
