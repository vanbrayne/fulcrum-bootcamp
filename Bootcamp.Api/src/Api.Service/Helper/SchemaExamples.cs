using System;
using Api.Service.Models;
using Swashbuckle.Swagger;

namespace Api.Service.Helper
{
    public class SchemaExamples : ISchemaFilter
    {

        public void Apply(Schema schema, SchemaRegistry schemaRegistry, Type type)
        {
            if (type == typeof(User))
            {
                schema.example = new User
                {
                    Name = "Anders Andersson",
                    Type = "External|Internal"
                };
            }
        }

    }
}