using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.Dto.ChuckNorrisDtos
{
    public class OpenChuckNorrisJokeResultDto
    {
        public List<object> Categories { get; set; }
        public string CreatedAt { get; set; }
        public string Id { get; set; }
        public string UpdatedAt { get; set; }
        public string Url { get; set; }
        public string Value { get; set; }


        public string Jokes { get; set; }
    }
}
