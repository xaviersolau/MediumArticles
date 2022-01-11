using Microsoft.AspNetCore.Mvc;
using SoloX.TableModel.Server;
using SoloX.TableModel.Server.Services;

namespace MyMeteo.Server.Controllers
{
    /// TableDataController is the controller that will serve all
    /// registered table data.
    [Route("api/[controller]")]
    [ApiController]
    public class TableDataController : TableDataControllerBase
    {
        /// Set up the controller with the TableData EndPoint Service
        /// that is used by the base controller class implementation.
        public TableDataController(ITableDataEndPointService tableDataEndPointService)
            : base(tableDataEndPointService)
        {
        }
    }
}
