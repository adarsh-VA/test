<template>
    <v-container class="mt-12">
      <v-btn fab fixed left color="black" class="white--text" to="/movies"><v-icon>mdi-arrow-left</v-icon></v-btn>
      <movie-form card-title="Edit Movie Details" :movie-object="editDetails"></movie-form>
    </v-container>
</template>

<script>
  import MovieForm from '@/components/MovieForm.vue';

  export default {
    data(){
        return {
            testData:'testing data'
        };
    },
    components:{
      MovieForm
    },
    methods:{
      async editMovie(data){
        await this.$store.dispatch('movies/editMovie',data);
        this.$router.push('/movies');
      }
    },
    computed:{
        editDetails(){
            return this.$store.getters['movies/editMovieDetails'];
        }
    }
  }
</script>