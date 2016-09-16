namespace FormsTest1
{
    public class TextModel
    {
        private string _texto;
        public TextModel()
        {

        }
        public string Texto { get { return _texto; } set { _texto = value; } }
        public int MyProperty { get; set; }
    }
}