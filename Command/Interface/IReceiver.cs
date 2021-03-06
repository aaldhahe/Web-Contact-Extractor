using System.Threading.Tasks;
using Web_Contact_Extractor.DTOs;
using System.Collections.Generic;
namespace Web_Contact_Extractor.Command
{
    public interface IReceiver 
    {
        public void Action();
        public Task<List<ContactDTO>> GetContactInfo();
        public Task<List<ContactDTO>> GetContactInfo(int deepCrawl);
        public IList<string> Urls { set; get; }
    }
}