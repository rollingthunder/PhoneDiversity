﻿namespace DiversityPhone.Services
{
    using System.Collections.Generic;
    using DiversityPhone.Model;

    public interface IOfflineVocabulary
    {
        void addTerms(IEnumerable<Term> terms);
        IList<Term> getTerms(int source);

        void addAnalyses(IEnumerable<Analysis> analyses);
        IList<Analysis> getAllAnalyses();
        IList<Analysis> getPossibleAnalyses(string taxonomicGroup);
        Analysis getAnalysis(int analysisID);

        void addAnalysisResults(IEnumerable<AnalysisResult> results);
        IList<AnalysisResult> getPossibleAnalysisResults(int AnalysisID);

        void addAnalysisTaxonomicGroups(IEnumerable<AnalysisTaxonomicGroup> groups);
        IList<AnalysisTaxonomicGroup> getAnalysisTaxonomicGroups(string taxonomicGroup);

        void addTaxonNames(IEnumerable<TaxonName> taxa, int tableID);
        IList<TaxonName> getTaxonNames(int tableID);
        IList<TaxonName> getTaxonNames(Term taxGroup);

        void addPropertyNames(IEnumerable<PropertyName> properties);
        IList<PropertyName> getPropertyNames(Property prop);
    }
}