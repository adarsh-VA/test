<template>
  <learning-survey @survey-submit="surveyAdd"></learning-survey>
  <user-experiences :results="surveys"></user-experiences>
</template>

<script>
import LearningSurvey from './components/survey/LearningSurvey.vue';
import UserExperiences from './components/survey/UserExperiences.vue';

export default{
  components:{
    LearningSurvey,
    UserExperiences
  },
  data(){
    return{
      surveys:[]
    };
  },
  methods:{
    surveyAdd(survey){
      const newSurvey={
        name:survey.userName,
        rating:survey.rating,
        id: new Date().toISOString()
      };
      this.surveys.push(newSurvey);
    }
  }
};
</script>

<style>
* {
  box-sizing: border-box;
}

html {
  font-family: sans-serif;
}

body {
  margin: 0;
}
</style>