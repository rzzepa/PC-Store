using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class ComputerCase
    {
        public int Id { get; set; }

        public string Producer { get; set; }

        public string ProducerCode{ get; set; }

        public string Color { get; set; }

        public string Backlit { get; set; }

        public float Height { get; set; }

        public float Width { get; set; }

        public float Depth { get; set; }

        public float Weight { get; set; }

        public string ComputerCaseType { get; set; }

        public string Compatibility { get; set; }

        public bool Window { get; set; }

        public bool Muted { get; set; }

        public int Usb20 { get; set; }

        public int Usb30 { get; set; }

        public int Usb31 { get; set; }

        public int Usb32 { get; set; }

        public int USBC { get; set; }

        public bool MemoryCardReader { get; set; }

        public bool SpeakerConnector { get; set; }

        public bool MicrophoneConnector { get; set; }

        public int ProductId { get; set; }

    }
}
