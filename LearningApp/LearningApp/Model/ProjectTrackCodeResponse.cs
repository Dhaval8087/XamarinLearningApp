using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
namespace LearningApp.Model
{
    public class ProjectTrackCodeResponse:Response
    {
        private ObservableCollection<ProjectTrackCode> _ProjectTrackCodes;

        public ObservableCollection<ProjectTrackCode> ProjectTrackCodes
        {
            get { return _ProjectTrackCodes; }
            set { _ProjectTrackCodes = value; }
        }

    }
    public class ProjectTrackCode
    {
        public int RecID { get; set; }
        public int TrackCodeID { get; set; }
        public string TrackCode { get; set; }            //TrackCdID
        public string TrackCodeName { get; set; }
        public string StartEffectiveDate { get; set; }
        public string EndEffectiveDate { get; set; }
        public CustomFields CustomFields { get; set; }
    }
}
