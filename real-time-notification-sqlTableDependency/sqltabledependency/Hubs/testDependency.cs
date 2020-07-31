using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sqltabledependency.Hubs
{
    public class testDependency:BaseDependency<Entity.test>
    {
        public testDependency() : base("test", Mapper.TestMapper.getTestMapper()) { }
    }
}
