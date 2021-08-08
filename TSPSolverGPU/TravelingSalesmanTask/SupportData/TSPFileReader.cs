using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace TSPSolverGPU
{
    internal static class TSPFileReader
    {
        /// <summary>
        /// Parses .tsp file
        /// </summary>
        /// <param name="path">.tsp file path</param>
        /// <returns>TSPTask instance</returns>
        public static TSPTask Parse(string path)
        {
            TSPTask task = new TSPTask();
            string line;
            using (var streamReader = new StreamReader(path))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.StartsWith("NAME", StringComparison.InvariantCultureIgnoreCase))
                    {
                        task.TaskName = ReadStringFromLine("Name", line);
                    }
                    else if (line.StartsWith("COMMENT", StringComparison.InvariantCultureIgnoreCase))
                    {
                        task.Comment = ReadStringFromLine("Comment", line);
                    }
                    else if (line.StartsWith("TYPE", StringComparison.InvariantCultureIgnoreCase))
                    {
                        task.Type = ReadStringFromLine("Type", line);
                    }
                    else if (line.StartsWith("DIMENSION", StringComparison.InvariantCultureIgnoreCase))
                    {
                        task.Dimension = ReadIntFromLine("Dimension", line);
                    }
                    else if (line.StartsWith("EDGE_WEIGHT_TYPE", StringComparison.InvariantCultureIgnoreCase))
                    {
                        task.EdgeWeightType = ReadStringFromLine("Edge weight type", line);
                    }
                    else if (line.StartsWith("DISPLAY_DATA_TYPE:", StringComparison.InvariantCultureIgnoreCase))
                    {
                        task.DisplayDataType = ReadStringFromLine("Display data type", line);
                    }
                    else if (line.StartsWith("NODE_COORD_SECTION", StringComparison.InvariantCultureIgnoreCase))
                    {
                        List<Coord> coords = new List<Coord>();
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            if (line.StartsWith("EOF", StringComparison.InvariantCultureIgnoreCase))
                            {
                                break;
                            }

                            line = line.Trim();
                            while (line.Contains("  "))
                            {
                                line = line.Replace("  ", " ");
                            }

                            string[] coord = line.Split(' ');
                            if (coord.Length == 3)
                            {
                                float x = float.Parse(coord[1], CultureInfo.InvariantCulture.NumberFormat);
                                float y = float.Parse(coord[2], CultureInfo.InvariantCulture.NumberFormat);
                                coords.Add(new Coord(x, y));
                            }
                            else
                            {
                                Debug.WriteLine($"ERROR\n{line}\nERROR");
                            }
                        }
                        task.Coords = coords.ToArray();
                    }
                }
            }
            return task;
        }

        private static string ReadStringFromLine(string sectionName, string line)
        {
            int index = line.IndexOf(':');
            if (index > 0)
            {
                line = line.Substring(index + 1).Trim();
            }

            return line;
        }
        private static int ReadIntFromLine(string sectionName, string line)
        {
            int index = line.IndexOf(':');
            if (index > 0)
            {
                line = line.Substring(index + 1).Trim();
            }

            return int.Parse(line);
        }

    }
}
