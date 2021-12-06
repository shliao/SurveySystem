using SurveySystem.ORM.DBModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SurveySystem.DBsource
{
    public class ListManager
    {
        public static List<Questionnaire> GetQuestionnaire()
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
        public static List<Questionnaire> GetQuestionnairebyKeyword(string keyword)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.Questionnaire
                                 where item.Caption.Contains(keyword)
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
        public static Questionnaire GetQuestionnaireID(int questionnaireid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.Questionnaire
                                 where item.QuestionnaireID == questionnaireid
                                 select item).FirstOrDefault();

                    var list = query;
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
        public static QuestionnaireDetails GetQuestionnaireDetailsID(int questionnaireid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.QuestionnaireDetails
                                 where item.QuestionnaireID == questionnaireid
                                 select item).FirstOrDefault();

                    var list = query;
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
        public static UserInfoSurvey_View GetSurveyID(Guid userinfoid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.UserInfoSurvey_View
                                 where item.UserInfoID == userinfoid
                                 select item).FirstOrDefault();

                    var list = query;
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
        public static List<UserInfoSurvey_View> GetSurveyUser(int userinfoid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.UserInfoSurvey_View
                                 where item.QuestionnaireID == userinfoid
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
        public static List<SurveyD_QuestD_View> GetSurvey(int userinfoid, Guid guid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.SurveyD_QuestD_View
                                 where item.QuestionnaireID == userinfoid && item.UserInfoID == guid
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
        public static List<QuestionnaireDetails> GetQuestionnaireDetails(int questionnaireid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.QuestionnaireDetails
                                 where item.QuestionnaireID == questionnaireid
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
        public static void CreatQuestionnaire(Questionnaire creatquestionnaire)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    context.Questionnaire.Add(creatquestionnaire);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static void CreatUserInfo(UserInfo userInfo)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    context.UserInfo.Add(userInfo);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static void AddSurveyDetails(SurveyDetails surveyDetails)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    context.SurveyDetails.Add(surveyDetails);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static void AddSurvey(Survey survey)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    context.Survey.Add(survey);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static bool UpdateQuestionnaire(int questionnaireid, Questionnaire questionnaire)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query = (from item in context.Questionnaire
                                 where item.QuestionnaireID == questionnaireid
                                 select item).FirstOrDefault();
                    if (query != null)
                    {
                        query.Caption = questionnaire.Caption;
                        query.QContent = questionnaire.QContent;
                        query.StartDate = questionnaire.StartDate;
                        query.EndDate = questionnaire.EndDate;
                        query.Status = questionnaire.Status;

                        context.SaveChanges();
                        return true;
                    }
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
        public static bool UpdateQuestionnaireDetails(int qdid, QuestionnaireDetails questdtl)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query = (from item in context.QuestionnaireDetails
                                 where item.QDID == qdid
                                 select item).FirstOrDefault();
                    if (query != null)
                    {
                        query.QuestionType = questdtl.QuestionType;
                        query.Question = questdtl.Question;
                        query.QOption = questdtl.QOption;
                        query.Required = questdtl.Required;

                        context.SaveChanges();
                        return true;
                    }
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
        public static void AddQuestionnaireDetails(QuestionnaireDetails QuestionnaireDetails)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    context.QuestionnaireDetails.Add(QuestionnaireDetails);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static void DeleteQuestionnaireDetails(int qdid)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var obj = context.QuestionnaireDetails.Where
                              (k => k.QDID == qdid).FirstOrDefault();

                    if (obj != null)
                    {
                        context.QuestionnaireDetails.Remove(obj);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static void DeleteQuestionnaire(int qdid)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var obj = context.Questionnaire.Where(j => j.QuestionnaireID == qdid).FirstOrDefault();
                    var obj2 = context.QuestionnaireDetails.Where(k => k.QuestionnaireID == qdid);

                    foreach (var item in obj2)
                    {
                        context.QuestionnaireDetails.Remove(item);
                    }

                    if (obj != null)
                    {
                        context.Questionnaire.Remove(obj);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static QuestionnaireDetails GetQuestDetailsID(int qdid)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.QuestionnaireDetails
                                 where item.QDID == qdid
                                 select item);

                    var list = query.FirstOrDefault();
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
        public static List<FAQ> GetFAQSeleteItem()
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.FAQ
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
        public static FAQ GetFAQ(string CustomName)
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.FAQ
                                 where item.CustomName == CustomName
                                 select item).FirstOrDefault();

                    var list = query;
                    return list;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return null;
                }
            }
        }
        public static void CreatFAQ(FAQ faq)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    context.FAQ.Add(faq);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static void DeleteFAQ(string name)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var obj = context.FAQ.Where
                              (k => k.CustomName == name).FirstOrDefault();

                    if (obj != null)
                    {
                        context.FAQ.Remove(obj);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
        public static bool UpdateFAQ(string customname, FAQ questionnaire)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query = (from item in context.FAQ
                                 where item.CustomName == customname
                                 select item).FirstOrDefault();
                    if (query != null)
                    {
                        query.CustomName = questionnaire.CustomName;
                        query.FAQType = questionnaire.FAQType;
                        query.Question = questionnaire.Question;
                        query.FOption = questionnaire.FOption;

                        context.SaveChanges();
                        return true;
                    }
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }
        public static List<Survey_View> GetUserSurveyDetails()
        {
            using (ContextModel context = new ContextModel())
            {
                try
                {
                    var query = (from item in context.Survey_View
                                 orderby item.QDID descending
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
        public static DataTable ConvertToDataTable<T>(IList<T> data)         //List轉DataTable
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
