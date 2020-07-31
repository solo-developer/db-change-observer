using sqltabledependency.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TableDependency;
using TableDependency.Abstracts;

namespace sqltabledependency.Mapper
{
    public class TestMapper
    {
        public static IModelToTableMapper<test> getTestMapper()
        {
            var mapper = new ModelToTableMapper<test>();
            mapper.AddMapping(model => model.id, "id");
            mapper.AddMapping(model => model.name, "name");
            mapper.AddMapping(model => model.roll, "roll");
            return mapper;
        }
    }
}
