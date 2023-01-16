import axios from 'axios';

const storeConfig={
  state: {
    movies:[]
  },
  mutations: {
    setMovies(state,payload){
        state.movies=payload;
    }
  },
  actions:{
    async loadMovies(context){
        const response = await axios.get('https://localhost:7156/movies');
        context.state.movies=response.data;
    }
  },
  getters:{
    allMovies(state){
        return state.movies;
    }
  }
}

export default storeConfig;