using BFCore.Config;
using BFWpf.Models.Config;
using BFWpf.Models.Execute;
using Prism.Commands;
using Prism.Mvvm;

namespace BFWpf.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string _codeText;
        private string _output;

        private readonly Executer _executer;

        public string CodeText
        {
            get { return this._codeText; }
            set { SetProperty(ref this._codeText, value); }
        }

        public string Output
        {
            get { return this._output; }
            set { SetProperty(ref this._output, value); }
        }

        public DelegateCommand RunCommand { get; private set; }

        public MainViewModel()
        {
            this.RunCommand = new DelegateCommand(Execute);

            var factory = new ConfigFactory();
            this._executer = new Executer(factory.Create<CommonConfig>(), factory.Create<BFCommandConfig>());
        }

        public void Execute()
        {
            this._executer.Reset();

            this._executer.Execute(this.CodeText);

            this.Output = this._executer.Output;
        }
    }
}
