<template>
    <v-container class="mt-12">
      <v-btn fab fixed left color="black" class="white--text" to="/movies"><v-icon>mdi-arrow-left</v-icon></v-btn>
      <v-card class="pa-5 mx-auto" :width="customWidth">
          <v-card-title primary-title>
              <h2>Enter Movie Details</h2> 
          </v-card-title>
          <hr>
          <v-form
            ref="form"
            v-model="valid"
            lazy-validation
            class="pa-4"
          >
            <v-text-field
              v-model="movieName"
              :rules="nameRules"
              label="Movie Name"
              required
            ></v-text-field>
  
            <v-text-field
              v-model="YOR"
              :rules="yorRules"
              label="Year Of Release"
              required
            ></v-text-field>
            <v-row
            align="center">
              <v-col cols="12" lg="10" md="9" sm="6">
                <v-select
                  v-model="Actors"
                  :items="actors"
                  :menu-props="{ maxHeight: '400' }"
                  label="Select Actors"
                  multiple
                  :rules="[v => !!v || 'Actors are required']"
                ></v-select>
              </v-col>
              <v-col cols="12" lg="2" md="3" sm="6">
                <v-btn color="grey darken-4" class="white--text" width="100%">Add Actor</v-btn>
              </v-col>
            </v-row>
            <v-row
            align="center">
              <v-col cols="12" lg="10" md="9" sm="6" >
                <v-select
                  v-model="Producers"
                  :items="producers"
                  :menu-props="{ maxHeight: '400' }"
                  label="Select Producers"
                  :rules="[v => !!v || 'Producer is required']"
                ></v-select>
              </v-col>
              <v-col cols="12" lg="2" md="3" sm="6" >
                <v-btn color="grey darken-4" class="white--text" width="100%">Add Producer</v-btn>
              </v-col>
            </v-row>
            
            <v-select
              v-model="Genres"
              :items="genres"
              :menu-props="{ maxHeight: '400' }"
              label="Select Genres"
              :rules="[v => v || 'Genre is required']"
              multiple
            ></v-select>
            <v-textarea
              outlined
              name="input-7-3"
              label="Movie Plot"
              rows="3"
              class="mt-3" 
              :rules="[v => !!v || 'Movie Plot is required']"
            ></v-textarea>
            <v-file-input
              accept="image/*"
              label="File input"
              :rules="[v => !!v || 'Select any Movie Poster']"
            ></v-file-input>
            <v-btn
              :disabled="!valid"
              color="success"
              class="mr-4 mt-4"
              @click="validate"
            >
              Submit
            </v-btn>
          </v-form>
      </v-card>       
    </v-container>
</template>


<script>
  export default {
    data: () => ({
      valid: true,
      movieName: '',
      nameRules: [
        v => !!v || 'Name is required',
      ],
      YOR: null,
      yorRules: [
        v => !!v || 'Year Of Release is required',
        v => /^[-+]?[0-9]{3}\.?[0-9]$/.test(v) || 'Year Of Release must be valid',
      ],
      Actors: null,
      actors: [
        'Actors 1',
        'Actors 2',
        'Actors 3',
        'Actors 4',
      ],
      Producers: null,
      producers: [
        'Producers 1',
        'Producers 2',
        'Producers 3',
        'Producers 4',
      ],
      Genres: null,
      genres: [
        'Genres 1',
        'Genres 2',
        'Genres 3',
        'Genres 4',
      ]
    }),
    computed:{
      customWidth(){
        var width = ''
        switch (this.$vuetify.breakpoint.name) {
          case 'sm': width = '100%'
            break;
          case 'md': width='100%'
            break;
          case 'lg': width= '70%'
            break;
          case 'xl': width= '70%'
            break;
        }
        return width;
      }
    },

    methods: {
      validate () {
        this.$refs.form.validate()
      },
      reset () {
        this.$refs.form.reset()
      },
      resetValidation () {
        this.$refs.form.resetValidation()
      },
    },
  }
</script>