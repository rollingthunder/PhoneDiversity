﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using DiversityService.Model;

namespace DiversityService
{
    // HINWEIS: Mit dem Befehl "Umbenennen" im Menü "Umgestalten" können Sie den Schnittstellennamen "IDivService" sowohl im Code als auch in der Konfigurationsdatei ändern.
    [ServiceContract]
    public interface IDiversityService
    {
        [OperationContract]
        IList<Project> GetProjectsForUser(UserProfile user);

        //Todo:
        //Contract Userinfo

        [OperationContract]
        IList<TermList> GetTaxonListsForUser(UserProfile user);
        [OperationContract]
        IEnumerable<TaxonName> DownloadTaxonList(string list);

        [OperationContract]
        IEnumerable<Term> GetStandardVocabulary();
        [OperationContract]
        IList<AnalysisResult> GetAnalysisResults(IList<int> analysisKeys);
        [OperationContract]
        IList<AnalysisResult> GetAnalysisTaxonomicGroupsResults(IList<int> analysisKeys);


        [OperationContract]
        IEnumerable<string> GetAvailablePropertyLists();
        [OperationContract]
        IEnumerable<PropertyName> DownloadPropertyList(string list);

        [OperationContract]
        IList<EventSeries> GetSeriesByDescription(string description);

        [OperationContract]
        IList<EventSeries> AllEventSeries();


        [OperationContract]
        HierarchySection InsertHierarchy(HierarchySection hierarchy);
    }   
}
