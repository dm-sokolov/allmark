using System;
using System.Collections.Generic;
using System.Text;

namespace AllMark.DTO
{
    public class AttributeDto: BaseDto
    {
        public int AttributeId { get; set; }
        public string AttributeValue { get; set; }
        public string ValueType { get; set; }
    }
}
