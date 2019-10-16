using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Code.Challenge.DataLayer.DTO;
using Code.Challenge.LogicLayer.Interface;

namespace Code.Challenge.LogicLayer
{
    public class HorseManagerLL : IHorseManagerLL
    {

        private readonly Func<RaceName, IRaceFileProcessor> _raceFile;

        public HorseManagerLL(Func<RaceName, IRaceFileProcessor> raceFile)
        {
            _raceFile = raceFile;
        }
        public async Task<List<Horse>> GetHorseDetails()
        {
            try
            {

                var mergedHorses = new List<Horse>();

                //TODO: Move this to configuration - appsettings
                //have this is the appsettings
                var location = System.Reflection.Assembly.GetEntryAssembly()?.Location;
                var filePath = System.IO.Path.GetDirectoryName(location) + "\\Feeds";

                if (!Directory.Exists(filePath)) return null;



                // Process the list of files found in the directory.
                var fileEntries = Directory.GetFiles(filePath);

                if (fileEntries == null)
                {
                    Console.WriteLine("Error: No Race Feed present");
                    return null;
                    //log error
                }
                foreach (var fileName in fileEntries)
                {
                    if (!Enum.TryParse<RaceName>(Path.GetFileNameWithoutExtension(fileName), ignoreCase: true,
                        out var raceName)) continue;

                    var raceFileProcessor = _raceFile(raceName);

                    if (raceFileProcessor == null)
                    {
                        Console.WriteLine("Error: No processor available for the feed");
                        //log error
                    }

                    if (raceFileProcessor == null) continue;
                    var horseData = await raceFileProcessor.Process(fileName);

                    if (horseData == null) continue;


                    mergedHorses.AddRange(horseData);
                }

              
                mergedHorses = mergedHorses.OrderBy(a => a.Price).ToList();

                return mergedHorses;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //log
                throw;
            }

        }
    }
}