<template>
    <v-container class="mt-12">
      <v-btn fab fixed left color="black" class="white--text" to="/movies"><v-icon>mdi-arrow-left</v-icon></v-btn>
      <movie-form card-title="Enter Movie Details" @movie-data="addMovie"></movie-form>
    </v-container>
</template>


<script>
  import MovieForm from '@/components/MovieForm.vue';

  export default {
    components:{
      MovieForm
    },
    methods:{
      addMovie(data){
        this.$store.dispatch('movies/addMovie',data);
      }
    }
  }
</script>