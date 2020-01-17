using BFCore.Config;
using BFCore.Execute;

namespace BFWpf.Models.Execute
{
    public class Executer : ExecuterBase
    {
        public string Output { get; private set; }

        public Executer(CommonConfig config, BFCommandConfig commandConfig) : base(config, commandConfig) { }

        protected override void Read()
        {
        }

        protected override void Write()
        {
            this.Output += (char)this._memory[this._index];
        }

        public void Reset()
        {
            this.Output = string.Empty;
        }
    }
}
