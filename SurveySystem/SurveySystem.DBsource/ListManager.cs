using SurveySystem.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveySystem.DBsource
{
    public class ListManager
    {
        public static List<Questionnaire> GetQuestionnaireID()
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.Questionnaire
                                 select item);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
        public static List<Questionnaire> GetQuestionnaireByDate(DateTime startTime, DateTime endTime)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    DateTime newEndTime = endTime.AddDays(1);

                    var query = (from item in context.Questionnaire
                                 where item.StartDate <= newEndTime && item.StartDate >= startTime
                                 select item);

                    var list = query.ToList();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
    }
}
