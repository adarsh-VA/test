import axios from 'axios';

export default{
    namespaced:true,
    state(){
      return{
          movies:[]
      }
    },
    mutations: {
      setMovies(state,payload){
          state.movies=payload;
      }
    },
    actions:{
      async loadMovies(context){
          const response = await axios.get('https://localhost:7156/movies');
          context.commit('setMovies',response.data);
      },
      async addMovie(context,payload){
        const posterReponse = await axios.post('https://localhost:7156/movies/upload',payload.coverImage);
        payload.coverImage=posterReponse.data;
        payload.language= "english";
        payload.profit= 0;

        console.log('upload success');
        console.log(payload);

        const movieResponse = await axios.post('https://localhost:7156/movies',payload);
        console.log(movieResponse);
      }
    },
    getters:{
      allMovies(state){
          return state.movies;
      }
    }
}
