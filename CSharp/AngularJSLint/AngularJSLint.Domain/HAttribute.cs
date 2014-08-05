using System.Collections.Generic;
namespace AngularJSLint.Domain
{
    public class HAttribute
    {
        public const string _NgController = "ng-controller";

        private Dictionary<string, string> fErrorMessages;
        private Dictionary<string, string> ErrorMessages
        {
            get
            {
                if (fErrorMessages == null)
                {
                    fErrorMessages = new Dictionary<string, string>();
                    fErrorMessages.Add(_NgController, "Use controllerAs syntax. Ex: \"storeControlle as store\"");
                }

                return fErrorMessages;
            }
        }

        public string Name { get; set; }
        public string Value { get; set; }

        public int LineNumber { get; set; }
        public int ColumnNumber { get; set; }
        
        public bool IsAngularAttribute()
        {
 	        return IsNgController();
        }

        public bool IsLint()
        {
            return IsLintNgController();
        }

        private bool IsNgController()
        {
            return Name.Equals(_NgController);
        }

        private bool IsLintNgController()
        {
            if (!IsNgController())
            {
                return true;
            }
             
            return Value.Contains(" as ");
        }

        public List<Error> LintErrors()
        {
            var errors = new List<Error>();
            if (!IsLintNgController()) 
            {
                errors.Add(new Error(LineNumber, ColumnNumber, ErrorMessages[_NgController]));
            }

            return errors;
        }
    }
}
