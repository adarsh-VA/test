<template>
    <v-card class="pa-5 mx-auto" :width="customWidth">
          <v-card-title primary-title>
              <h2>{{cardTitle}}</h2> 
          </v-card-title>
          <hr>
          <v-form
            ref="form"
            v-model="valid"
            lazy-validation
            class="pa-4"
            @submit.prevent
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
              <v-col cols="12" lg="9" md="9" sm="6">
                <v-select
                  v-model="Actors"
                  :items="actors"
                  item-text="state"
                  item-value="val"
                  :menu-props="{ maxHeight: '400' }"
                  label="Select Actors"
                  multiple
                  :rules="[v => !!v || 'Actors are required']"
                ></v-select>
              </v-col>
              <v-col cols="12" lg="3" md="3" sm="6">
                <v-btn color="grey darken-4" class="white--text" width="100%" @click.stop="dialog = true" @click="formLabel='Enter Actor Details'">Add Actor</v-btn>
              </v-col>
            </v-row>
            <v-row
            align="center">
              <v-col cols="12" lg="9" md="9" sm="6" >
                <v-select
                  v-model="Producer"
                  :items="producers"
                  item-text="state"
                  item-value="val"
                  :menu-props="{ maxHeight: '400' }"
                  label="Select Producers"
                  :rules="[v => !!v || 'Producer is required']"
                ></v-select>
              </v-col>
              <v-col cols="12" lg="3" md="3" sm="6" >
                <v-btn color="grey darken-4" class="white--text" width="100%" @click.stop="dialog = true" @click="formLabel='Enter Producer Details'">Add Producer</v-btn>
              </v-col>
            </v-row>
            
            <v-row
            align="center">
              <v-col cols="12" lg="9" md="9" sm="6" >
                <v-select
                  v-model="Genres"
                  :items="genres"
                  item-text="state"
                  item-value="val"
                  :menu-props="{ maxHeight: '400' }"
                  label="Select Genres"
                  :rules="[v => !!v || 'Genre is required']"
                  multiple
                ></v-select>
              </v-col>
              <v-col cols="12" lg="3" md="3" sm="6" >
                <v-btn color="grey darken-4" class="white--text" width="100%" @click.stop="dialog = true" @click="formLabel='Enter Genre Details'">Add Genre</v-btn>
              </v-col>
            </v-row>

            <v-textarea
              outlined
              name="input-7-3"
              label="Movie Plot"
              rows="3"
              class="mt-3" 
              :rules="[v => !!v || 'Movie Plot is required']"
              v-model="plot"
            ></v-textarea>
            <v-file-input
              accept="image/*"
              label="File input"
              :rules="[v => !!v || 'Select any Movie Poster']"
              v-model="poster"
            ></v-file-input>
            <v-btn
              :disabled="!valid"
              color="success"
              class="mr-4 mt-4"
              @click="submit"
            >
              Submit
            </v-btn>
          </v-form> 

          <!-- Person Form dialog -->
          <v-dialog
            v-model="dialog"
            width="500"
          >
            <person-form :form-label="personFormLabel" @person-data="addPerson" @close-form="dialog=false"></person-form>
          </v-dialog>
      </v-card>
           
</template>

<script>
    import PersonForm from './PersonForm.vue';

  export default {
    components:{
        PersonForm,
    },
    emits:['movie-data'],
    props:['cardTitle'],
    data(){
        return {
            formLabel:'',
            dialog:false,
          valid: false,
          formValid:false,
          movieName: null,
          nameRules: [
            v => !!v || 'Name is required',
          ],
          YOR: null,
          yorRules: [
            v => !!v || 'Year Of Release is required',
            v => /^[-+]?[0-9]{3}\.?[0-9]$/.test(v) || 'Year Of Release must be valid',
          ],
          Actors: null,
          actors: [],
          Producer: null,
          producers: [],
          Genres: null,
          genres: [],
          plot:null,
          poster:null,
          personFormData:null
        }
    },
    computed:{
      customWidth(){
        var width = ''
        switch (this.$vuetify.breakpoint.name) {
          case 'sm': width = '100%'
            break;
          case 'md': width = '100%'
            break;
          case 'lg': width = '70%'
            break;
          case 'xl': width = '70%'
            break;
        }
        return width;
      },
      personFormLabel(){
        return this.formLabel;
      }
    },

    methods: {
        check(){
            this.formValid = false
            if(
                this.movieName !=null 
                && this.YOR !=null
                && this.Actors !=null
                && this.Producer !=null
                && this.plot !=null
                && this.Genres !=null
            ){
                this.formValid = true;
            }
            console.log(this.formValid);
        },
        submit () {
            this.$refs.form.validate()
            this.check();
            if(this.formValid){
                const formData = new FormData();
                formData.append('file', this.poster);
                var movie ={
                    name:this.movieName,
                    yearOfRelease:this.YOR,
                    plot:this.plot,
                    actorIds:this.Actors.toString(),
                    genreIds:this.Genres.toString(),
                    producerId:this.Producer.toString(),
                    coverImage:formData
                }
                console.log(movie);
                this.$emit('movie-data',movie);
            }
        },
        async loadActors(){
            await this.$store.dispatch('actors/loadActors');

            const actors = this.$store.getters['actors/allActors'];

            actors.forEach(actor => {
                this.actors.push({state:actor.name,val:actor.id});
            });

        },
        async loadProducers(){
            await this.$store.dispatch('producers/loadProducers');

            const producers = this.$store.getters['producers/allProducers'];

            producers.forEach(x => {
                this.producers.push({state:x.name,val:x.id});
            });

        },
        async loadGenres(){
            await this.$store.dispatch('genres/loadGenres');

            const genres = this.$store.getters['genres/allGenres'];

            genres.forEach(x => {
                this.genres.push({state:x.name,val:x.id});
            });

        },
        async addPerson(data,type){
            this.dialog=false;
            if(type=='actor'){
                await this.$store.dispatch('actors/addActor',data)
                this.loadActors();
            }
            else if(type == 'producer'){
                await this.$store.dispatch('producers/addProducer',data)
                this.loadProducers();
            }
            else{
                await this.$store.dispatch('genres/addGenre',data)
                this.loadGenres();
            }
        }
    },
    created(){
        this.loadActors();
        this.loadProducers();
        this.loadGenres();
    }
  }
</script>