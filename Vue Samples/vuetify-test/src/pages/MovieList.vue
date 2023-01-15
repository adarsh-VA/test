<template>
    <v-container fluid>
      <v-btn fab fixed right color="grey darken-4" class="white--text" to="/add"><v-icon>mdi-plus</v-icon></v-btn>
      <v-row class="mx-lg-16 mt-3">
        <v-col v-for="movie in movies" :key="movie" justify-center>
          <movie-item :name="movie"></movie-item>
        </v-col>
      </v-row>
    </v-container>
</template>

<script>
import MovieItem from '@/components/movieListing/MovieItem.vue';

export default {
  components:{
    MovieItem
  },
  data(){
    return {
      movies:["avengers","black-widow","dune","godzilla","iron-man","john-wick","joker","jurassic-park","lord-of-the-rings","mad-max","star-war","suicide-squad","terminator","warcraft"],
    }
  }

}
</script>