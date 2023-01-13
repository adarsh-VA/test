import axios from "axios";

export default{
    namespaced:true,
    state(){
        return{
            requests:[]
        }
    },
    mutations:{
      addRequest(state,payload){
        state.requests.push(payload);
      },
      setRequests(state,payload){
        state.requests=payload;
      }
    },
    actions:{
      async contactCoach(context,payload){
        const newRequest={
            coachId:payload.coachId,
            userEmail:payload.email,
            message:payload.message
        };

        const response = await axios.post(`https://vue-test-500ff-default-rtdb.firebaseio.com/requests/${payload.coachId}.json`,newRequest);

        const responseData = await response.data;

        newRequest.id=responseData.name;

        context.commit('addRequest',newRequest);
      },
      async fetchRequests(context){
        const coachId = context.rootGetters.userId;
        const response = await axios.get(`https://vue-test-500ff-default-rtdb.firebaseio.com/requests/${coachId}.json`);

        const responseData= response.data;

        const requests=[];

        for (const key in responseData){
            const newRequest={
                id:key,
                coachId:coachId,
                userEmail:responseData[key].userEmail,
                message:responseData[key].message
            };
            requests.push(newRequest);
        }

        context.commit('setRequests',requests);
      }
    },
    getters:{
        requests(state,_getters,_rootState,rootGetters){
            return state.requests.filter(r=>r.coachId===rootGetters.userId);
        },
        hasRequests(_state,getters){
            return getters.requests && getters.requests.length > 0;
        }
    }
}