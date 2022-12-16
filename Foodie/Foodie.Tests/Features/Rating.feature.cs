﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Foodie.Tests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class RatingResourceFeature : object, Xunit.IClassFixture<RatingResourceFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Rating.feature"
#line hidden
        
        public RatingResourceFeature(RatingResourceFeature.FixtureData fixtureData, Foodie_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Rating Resource", "Users can Rate dishes and fetch those details", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Get Ratings")]
        [Xunit.TraitAttribute("FeatureTitle", "Rating Resource")]
        [Xunit.TraitAttribute("Description", "Get Ratings")]
        [Xunit.InlineDataAttribute("/restaurants/1/users/1/ratings", "200", "[{\"id\":1,\"name\":\"Samosa\",\"myRating\":4,\"avgRating\":4},{\"id\":2,\"name\":\"Curd\",\"myRat" +
            "ing\":4,\"avgRating\":3.5}]", new string[] {
                "ValidData"})]
        [Xunit.InlineDataAttribute("/restaurants/19/users/1/ratings", "404", "Restaurant Not Found!", new string[] {
                "InvalidData"})]
        [Xunit.InlineDataAttribute("/restaurants/1/users/15/ratings", "404", "User Not Found!", new string[] {
                "InvalidData"})]
        [Xunit.InlineDataAttribute("/restaurants/0/users/1/ratings", "400", "Restaurant Id should not be Zero", new string[] {
                "InvalidData"})]
        public virtual void GetRatings(string request, string statusCode, string responseBody, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("request", request);
            argumentsOfScenario.Add("statusCode", statusCode);
            argumentsOfScenario.Add("responseBody", responseBody);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get Ratings", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 7
 testRunner.When(string.Format("I make GET Request \'{0}\'", request), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 8
 testRunner.Then(string.Format("response code must be \'{0}\'", statusCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 9
 testRunner.And(string.Format("response data must look like \'{0}\'", responseBody), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Create Rating")]
        [Xunit.TraitAttribute("FeatureTitle", "Rating Resource")]
        [Xunit.TraitAttribute("Description", "Create Rating")]
        [Xunit.InlineDataAttribute("/restaurants/2/Users/1/Dishes/1/ratings", "{\"Rating\":5.0}", "You Rated 5", "201", new string[] {
                "ValidData"})]
        [Xunit.InlineDataAttribute("/restaurants/1/Users/1/Dishes/1/ratings", "{\"Rating\":6.0}", "Rating should be in 1 to 5", "400", new string[] {
                "InvalidData"})]
        [Xunit.InlineDataAttribute("/restaurants/1/Users/1/Dishes/1/ratings", "{\"Rating\": 0}", "Rating should be in 1 to 5", "400", new string[] {
                "InvalidData"})]
        [Xunit.InlineDataAttribute("/restaurants/10/Users/1/Dishes/1/ratings", "{\"Rating\":5.0}", "Restaurant Not Found!", "404", new string[] {
                "InvalidData"})]
        [Xunit.InlineDataAttribute("/restaurants/1/Users/14/Dishes/1/ratings", "{\"Rating\":5.0}", "User Not Found!", "404", new string[] {
                "InvalidData"})]
        [Xunit.InlineDataAttribute("/restaurants/1/Users/1/Dishes/16/ratings", "{\"Rating\":5.0}", "Dish Not Found!", "404", new string[] {
                "InvalidData"})]
        [Xunit.InlineDataAttribute("/restaurants/0/Users/1/Dishes/1/ratings", "{\"Rating\":5.0}", "Restaurant Id should not be Zero", "400", new string[] {
                "InvalidData"})]
        public virtual void CreateRating(string request, string requestBody, string responseBody, string responseCode, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("request", request);
            argumentsOfScenario.Add("requestBody", requestBody);
            argumentsOfScenario.Add("responseBody", responseBody);
            argumentsOfScenario.Add("responseCode", responseCode);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create Rating", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 21
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 22
 testRunner.Given("I am a client", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 23
 testRunner.When(string.Format("I make POST Request \'{0}\' with following data \'{1}\'", request, requestBody), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 24
 testRunner.Then(string.Format("response code must be \'{0}\'", responseCode), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 25
 testRunner.And(string.Format("response data must look like \'{0}\'", responseBody), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                RatingResourceFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                RatingResourceFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
