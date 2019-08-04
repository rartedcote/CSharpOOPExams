using MXGP.Models.Riders.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Repositories
{
    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            return Models.FirstOrDefault(m => m.Name == name);
        }
    }
}