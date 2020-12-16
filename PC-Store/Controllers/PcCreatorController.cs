using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC_Store.Data;
using PC_Store.Infrastructure;
using PC_Store.Models;
using PC_Store.structure;
using PC_Store.Views.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Controllers
{
    public class PcCreatorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private PCCreator _PCCreator;

        public PcCreatorController(ApplicationDbContext context, PCCreator PCCreator)
        {
            _context = context;
            _PCCreator = PCCreator;
        }

        public IActionResult Index()
        {
            PCCreator creator = _PCCreator.getPcCreator(_PCCreator.PcCreatorId);
            if (creator!= null)
            {
                _PCCreator = creator;
            }
            else
            {
                _PCCreator = new PCCreator(_context)
                {
                GraphicCardProduct = null,
                ComputerCaseProduct = null,
                ProcessorProduct = null,
                RamProduct = null,
                PowerSupplyProduct = null,
                MotherboardProduct = null,
                PcCreatorId=_PCCreator.PcCreatorId,
                ModifyDate = DateTime.Now
                };
                _context.pCCreators.Add(_PCCreator);
                _context.SaveChanges();
            }

            return View(_PCCreator);
        }


        public async Task<IActionResult> MotherboardListCreator(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_desc" : "price_asc";

            var MotherBoard =
            from MCL in _context.motherboardCreatorLists
            where MCL.PcCreatorId == _PCCreator.PcCreatorId
            select new MotherboardCreatorList
            {
                Id=MCL.Id,
                PcCreatorId=MCL.PcCreatorId,
                Producer= MCL.Producer,
                ProducerCode= MCL.ProducerCode,
                Standard= MCL.Standard,
                Chipset= MCL.Chipset,
                SocketType= MCL.SocketType,
                Technologies= MCL.Technologies,
                StandardMemory= MCL.StandardMemory,
                ConnectorType= MCL.ConnectorType,
                NumberOfMemorySlots= MCL.NumberOfMemorySlots,
                MaximumAmountOfMemory= MCL.MaximumAmountOfMemory,
                MultiChannelArchitecture= MCL.MultiChannelArchitecture,
                IntegratedGraphicsCardSupport = MCL.IntegratedGraphicsCardSupport,
                GraphicsChipset = MCL.GraphicsChipset,
                CombiningCards = MCL.CombiningCards,
                SoundChipset = MCL.SoundChipset,
                AudioChannels = MCL.AudioChannels,
                IntegratedNetworkCard = MCL.IntegratedNetworkCard,
                NetworkCardChipset = MCL.NetworkCardChipset,
                Price = MCL.Price,
                Name = MCL.Name,
                Picture = MCL.Picture
            };

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                MotherBoard = MotherBoard.Where(s => s.Producer.ToLower().Contains(searchString.ToLower()) || s.SocketType.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    MotherBoard = MotherBoard.OrderByDescending(s => s.Price);
                    break;
                default:
                    MotherBoard = MotherBoard.OrderBy(s => s.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<MotherboardCreatorList>.CreateAsync(MotherBoard.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> ProcessorListCreator(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_desc" : "price_asc";

            var processors =
            from MCL in _context.processorCreatorLists
            where MCL.PcCreatorId == _PCCreator.PcCreatorId
            select new ProcessorCreatorList
            {
                PcCreatorId =MCL.PcCreatorId,
                Producer=MCL.Producer,
                Line=MCL.Line,
                Cooling=MCL.Cooling,
                SocketType=MCL.SocketType,
                NumberOfCores=MCL.NumberOfCores,
                NumberOfThreads=MCL.NumberOfThreads,
                ProcessorClockFrequency=MCL.ProcessorClockFrequency,
                TurboMaximumFrequency=MCL.TurboMaximumFrequency,
                IntegratedGraphics=MCL.IntegratedGraphics,
                UnlockedMultiplier=MCL.UnlockedMultiplier,
                Architecture=MCL.Architecture,
                TypesOfSupportedMemory=MCL.TypesOfSupportedMemory,
                Price=MCL.Price,
                Name=MCL.Name,
                Picture=MCL.Picture,
                Id=MCL.Id
            };
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                processors = processors.Where(s => s.Producer.ToLower().Contains(searchString.ToLower()) || s.SocketType.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    processors = processors.OrderByDescending(s => s.Price);
                    break;
                default:
                    processors = processors.OrderBy(s => s.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<ProcessorCreatorList>.CreateAsync(processors.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> PowerSupplyListCreator(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_desc" : "price_asc";

            var powersupply =
            from MCL in _context.powerSupplyCreatorLists
            where MCL.PcCreatorId == _PCCreator.PcCreatorId
            select new PowerSupplyCreatorList
            {
                PcCreatorId=MCL.PcCreatorId,
                Producer=MCL.Producer,
                ProducerCode=MCL.ProducerCode,
                Standard=MCL.Standard,
                Power=MCL.Power,
                EfficiencyCertificate=MCL.EfficiencyCertificate,
                PFCSystem=MCL.PFCSystem,
                Efficiency=MCL.Efficiency,
                CoolingType=MCL.CoolingType,
                Diameter=MCL.Diameter,
                Security=MCL.Security,
                ModularCabling=MCL.ModularCabling,
                ATX24pin204=MCL.ATX24pin204,
                PCIE8pin62=MCL.PCIE8pin62,
                PCIE8pin=MCL.PCIE8pin,
                PCIE6pin=MCL.PCIE6pin,
                CPU44pin8=MCL.CPU44pin8,
                CPU8pin=MCL.CPU8pin,
                CPU4pin=MCL.CPU4pin,
                SATA=MCL.SATA,
                Molex=MCL.Molex,
                Height=MCL.Height,
                Width=MCL.Width,
                Depth=MCL.Depth,
                Backlight=MCL.Backlight,
                Price=MCL.Price,
                Name=MCL.Name,
                Picture=MCL.Picture,
                Id=MCL.Id
            };
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                powersupply = powersupply.Where(s => s.Producer.ToLower().Contains(searchString.ToLower()) || s.Standard.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    powersupply = powersupply.OrderByDescending(s => s.Price);
                    break;
                default:
                    powersupply = powersupply.OrderBy(s => s.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<PowerSupplyCreatorList>.CreateAsync(powersupply.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public async Task<IActionResult> RamListCreator(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_desc" : "price_asc";

            var rams =
            from MCL in _context.ramCreatorLists
            where MCL.PcCreatorId == _PCCreator.PcCreatorId
            select new RamCreatorList
            {
                PcCreatorId=MCL.PcCreatorId,
                Producer=MCL.Producer,
                ProducerCode=MCL.ProducerCode,
                Line=MCL.Line,
                ConnectorType=MCL.ConnectorType,
                MemoryType=MCL.MemoryType,
                Cooling=MCL.Cooling,
                LowProfile=MCL.LowProfile,
                TotalCapacity=MCL.TotalCapacity,
                NumberOfModules=MCL.NumberOfModules,
                Frequency=MCL.Frequency,
                Delay=MCL.Delay,
                Voltage=MCL.Voltage,
                Backlight=MCL.Backlight,
                Price=MCL.Price,
                Name=MCL.Name,
                Picture=MCL.Picture,
                Id=MCL.Id
            };
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                rams = rams.Where(s => s.Producer.ToLower().Contains(searchString.ToLower()) || s.ProducerCode.ToLower().Contains(searchString.ToLower()) || s.MemoryType.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    rams = rams.OrderByDescending(s => s.Price);
                    break;
                default:
                    rams = rams.OrderBy(s => s.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<RamCreatorList>.CreateAsync(rams.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> ComputerCaseListCreator(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_desc" : "price_asc";

            var computercase =
            from MCL in _context.ComputerCaseCreatorLists
            where MCL.PcCreatorId == _PCCreator.PcCreatorId
            select new ComputerCaseCreatorList
            {
                PcCreatorId=MCL.PcCreatorId,
                Producer=MCL.Producer,
                ProducerCode=MCL.ProducerCode,
                Color=MCL.Color,
                Backlit=MCL.Backlit,
                Height=MCL.Height,
                Width=MCL.Width,
                Depth=MCL.Depth,
                Weight=MCL.Weight,
                ComputerCaseType=MCL.ComputerCaseType,
                Compatibility=MCL.Compatibility,
                Window=MCL.Window,
                Muted=MCL.Muted,
                Usb20=MCL.Usb20,
                Usb30=MCL.Usb30,
                Usb31=MCL.Usb31,
                Usb32=MCL.Usb32,
                USBC=MCL.USBC,
                MemoryCardReader=MCL.MemoryCardReader,
                SpeakerConnector=MCL.SpeakerConnector,
                MicrophoneConnector=MCL.MicrophoneConnector,
                Price=MCL.Price,
                Name=MCL.Name,
                Picture=MCL.Picture,
                Id=MCL.Id
            };
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                computercase = computercase.Where(s => s.Producer.ToLower().Contains(searchString.ToLower()) || s.Compatibility.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    computercase = computercase.OrderByDescending(s => s.Price);
                    break;
                default:
                    computercase = computercase.OrderBy(s => s.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<ComputerCaseCreatorList>.CreateAsync(computercase.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        public async Task<IActionResult> GraphicCardListCreator(string sortOrder, string searchString, string currentFilter, int? pageNumber)
        {
            ViewData["sortOrder"] = sortOrder == "price_desc" ? "price_desc" : "price_asc";

            var graphiccard =
            from MCL in _context.graphicCardCreatorLists
            where MCL.PcCreatorId == _PCCreator.PcCreatorId
            select new GraphicCardCreatorList
            {
                PcCreatorId=MCL.PcCreatorId,
                Producer=MCL.Producer,
                ProducerCode=MCL.ProducerCode,
                ProducerChipset=MCL.ProducerChipset,
                CoreClock=MCL.CoreClock,
                CoreClockBoost=MCL.CoreClockBoost,
                ConnectorType=MCL.ConnectorType,
                VerConnectorType=MCL.VerConnectorType,
                Resolution=MCL.Resolution,
                RecommendedPSUPower=MCL.RecommendedPSUPower,
                AmountOfRAM=MCL.AmountOfRAM,
                TypeOfRAM=MCL.TypeOfRAM,
                DataBus=MCL.DataBus,
                MemoryClock=MCL.MemoryClock,
                CoolingType=MCL.CoolingType,
                NumberOfFans=MCL.NumberOfFans,
                DSub=MCL.DSub,
                DisplayPort=MCL.DisplayPort,
                HDMI=MCL.HDMI,
                DVI=MCL.DVI,
                Price=MCL.Price,
                Name=MCL.Name,
                Picture=MCL.Picture,
                Id=MCL.Id
            };
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                graphiccard = graphiccard.Where(s => s.Producer.ToLower().Contains(searchString.ToLower()) || s.ProducerChipset.ToLower().Contains(searchString.ToLower()) || s.ProducerCode.ToLower().Contains(searchString.ToLower()));
            }

            switch (sortOrder)
            {
                case "price_desc":
                    graphiccard = graphiccard.OrderByDescending(s => s.Price);
                    break;
                default:
                    graphiccard = graphiccard.OrderBy(s => s.Price);
                    break;
            }

            int pageSize = 15;
            return View(await PaginatedList<GraphicCardCreatorList>.CreateAsync(graphiccard.AsNoTracking(), pageNumber ?? 1, pageSize));
        }


        public ViewResult ComputerCaseCreatorDetails(int? id)
        {
            var ComputerCase = _context.ComputerCaseCreatorLists.Where(p => p.PcCreatorId.Equals(_PCCreator.PcCreatorId)).Where(p=>p.Id==id).FirstOrDefault();
            return View(ComputerCase);
        }

        public ViewResult MotherboardCreatorDetails(int? id)
        {
            var MotherBoard = _context.motherboardCreatorLists.Where(p => p.PcCreatorId.Equals(_PCCreator.PcCreatorId)).Where(p => p.Id == id).FirstOrDefault();
            return View(MotherBoard);
        }

        public ViewResult PowerSupplyCreatorDetails(int? id)
        {
            var powerSupply = _context.powerSupplyCreatorLists.Where(p => p.PcCreatorId.Equals(_PCCreator.PcCreatorId)).Where(p => p.Id == id).FirstOrDefault();
            return View(powerSupply);
        }

        public ViewResult ProcessorCreatorDetails(int? id)
        {
            var Processor = _context.processorCreatorLists.Where(p => p.PcCreatorId.Equals(_PCCreator.PcCreatorId)).Where(p => p.Id == id).FirstOrDefault();
            return View(Processor);
        }

        public ViewResult RamCreatorDetails(int? id)
        {
            var Ram = _context.ramCreatorLists.Where(p => p.PcCreatorId.Equals(_PCCreator.PcCreatorId)).Where(p => p.Id == id).FirstOrDefault();
            return View(Ram);
        }

        public ViewResult GraphicCardCreatorDetails(int? id)
        {
            var graphiccard = _context.graphicCardCreatorLists.Where(p => p.PcCreatorId.Equals(_PCCreator.PcCreatorId)).Where(p => p.Id == id).FirstOrDefault();
            return View(graphiccard);
        }


        public RedirectToActionResult AddToCreator(int? id)
        {
            _PCCreator.AddToCreator(id);

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromCreator(int? id)
        {
            _PCCreator.RemoveFromCreator(id);

            return RedirectToAction("Index");
        }

    }
}
