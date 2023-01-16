import axios from 'axios';

export default{
    namespaced:true,
    state(){
        return{
            coaches:[
                {
                  id: 'c1',
                  firstName: 'Maximilian',
                  lastName: 'Schwarzmüller',
                  areas: ['frontend', 'backend', 'career'],
                  description:
                    "I'm Maximilian and I've worked as a freelance web developer for years. Let me help you become a developer as well!",
                  hourlyRate: 30
                },
                {
                  id: 'c2',
                  firstName: 'Julie',
                  lastName: 'Jones',
                  areas: ['frontend', 'career'],
                  description:
                    'I am Julie and as a senior developer in a big tech company, I can help you get your first job or progress in your current role.',
                  hourlyRate: 30
                }
            ],
            lastFetch:null
        }
    },
    mutations:{
      registerCoach(state,payload){
        state.coaches.push(payload);
      },
      setCoaches(state,payload){
        state.coaches=payload
      },
      setTimestamp(state,payload){
        state.lastFetch = payload;
      }
    },
    actions:{
      async registerCoach(context,data){
        const coachId = context.rootGetters.userId;
        const coachData={
          firstName:data.first,
          lastName:data.last,
          description:data.desc,
          hourlyRate:data.rate,
          areas:data.areas
        };

        const response = await axios.put(`https://vue-test-500ff-default-rtdb.firebaseio.com/coaches/${coachId}.json`,coachData);

        if(!response.ok){
          //error
        }
        context.commit('registerCoach',{...coachData , id:coachId});
      },
      async loadCoaches(context){
        const currentTime = new Date().getTime();
        if(!((currentTime - context.state.lastFetch)/1000 >60) && context.state.lastFetch !=null){
          return;
        }
        
        console.log('coach list created');
        const response = await axios.get(`https://vue-test-500ff-default-rtdb.firebaseio.com/coaches.json`);

        const responseData = await response.data;

        if(!response.ok){
          //error
        }

        const coaches=[];

        for (const key in responseData){
          const coach={
            id:key,
            firstName:responseData[key].firstName,
            lastName:responseData[key].lastName,
            description:responseData[key].description,
            hourlyRate:responseData[key].hourlyRate,
            areas:responseData[key].areas
          };
          coaches.push(coach);
        }
        context.commit('setCoaches',coaches);
        context.commit('setTimestamp',new Date().getTime());
      }
    },
    getters:{
        coaches(state){
            return state.coaches;
        },
        hasCoaches(state){
            return state.coaches && state.coaches.length > 0;
        }
    }
}