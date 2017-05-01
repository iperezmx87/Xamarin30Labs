using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCLProject
{
    
    public class AppValidator
    {
        IDialog dialog;

        public string email { get; set; }
        public string password { get; set; }
        public string device { get; set; }

        public AppValidator(IDialog performDialog)
        {
            dialog = performDialog;
        }

        public async void Validate()
        {
            string result;

            var serviceClient = new SALLab04.ServiceClient();
            var svcResult = await serviceClient.ValidateAsync(
                email, password, device
                );

            result = $"{svcResult.Status}\n{svcResult.Fullname}\n{svcResult.Token}";
            

            dialog.Show(result);
        }
    }
}
