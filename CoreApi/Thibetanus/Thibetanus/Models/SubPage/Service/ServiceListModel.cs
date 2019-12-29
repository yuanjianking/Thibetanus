using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Thibetanus.Models.SubPage.Service
{
    public class ServiceListModel
    {
        private List<ServiceGroupModel> _serviceGroups = null;
        private Dictionary<string, List<ServiceModel>> _services = null;

        public List<ServiceGroupModel> ServiceGroups { get => _serviceGroups; set => _serviceGroups = value; }
        public Dictionary<string, List<ServiceModel>> Services { get => _services; set => _services = value; }
    }
}
