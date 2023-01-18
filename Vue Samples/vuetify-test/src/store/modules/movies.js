import axios from 'axios';
import { getStorage, ref, deleteObject } from "firebase/storage";
import { initializeApp } from "firebase/app";

export default{
    namespaced:true,
    state(){
      return{
          movies:[],
          editMovie:null
      }
    },
    mutations: {
      setMovies(state,payload){
          state.movies=payload;
      },
      removeMovie(state,payload){
        var idx =state.movies.findIndex(m=>m.id==payload);
        state.movies.splice(idx,1);        
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
      },
      async deleteMovie(context,payload){

        // deleting the image from the firebase.
        const firebaseConfig = {
          authDomain: "vue-imdb-cac6a.appspot.com",
          // The value of `databaseURL` depends on the location of the database
          databaseURL: "https://vue-imdb-cac6a.firebaseio.com",
          projectId: "vue-imdb-cac6a",
          storageBucket: "vue-imdb-cac6a.appspot.com"
        };

        const app = initializeApp(firebaseConfig);

        const storage = getStorage(app);
        
        // Create a reference to the file to delete
        const desertRef = ref(storage,payload.poster);
        
        // Delete the file
        await deleteObject(desertRef).then(() => {
          // File deleted successfully
        }).catch(() => {
          // Uh-oh, an error occurred!
        });

        
        // delete movie from the database.
        context.commit('removeMovie',payload.id);
        const movieResponse = await axios.delete(`https://localhost:7156/movies/${payload.id}`);
        console.log(movieResponse);
      },
      // async editMovie(context,payload){
      //   const response = axios.put()
      // }
    },
    getters:{
      allMovies(state){
          return state.movies;
      },
      editMovieDetails(state){
        return state.editMovie;
      }
    }
}
