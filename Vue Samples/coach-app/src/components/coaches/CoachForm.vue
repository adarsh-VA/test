<template>
    <form @submit.prevent="submitForm()">
        <div class="form-control" :class="{invalid:!firstName.isValid}">
            <label for="firstName">FirstName</label>
            <input type="text" id="firstName" v-model.trim="firstName.val">
            <p v-if="!firstName.isValid">please enter firstName</p>
        </div>
        <div class="form-control" :class="{invalid:!lastName.isValid}">
            <label for="lastName">LastName</label>
            <input type="text" id="lastName" v-model.trim="lastName.val">
        </div>
        <div class="form-control" :class="{invalid:!description.isValid}">
            <label for="description">Description</label>
            <textarea name="" id="description" rows="5" v-model.trim="description.val"></textarea>
        </div>
        <div class="form-control" :class="{invalid:!rate.isValid}">
            <label for="rate">Hourly Rate</label>
            <input type="number" id="rate" v-model.number="rate.val">
        </div>
        <div class="form-control" :class="{invalid:!areas.isValid}">
            <h3>Areas of Expertise</h3>
            <div>
                <input type="checkbox" name="" id="frontend" value="frontend" v-model="areas.val">
                <label for="frontend">Fronted Development</label>
            </div>
            <div>
                <input type="checkbox" name="" id="backend" value="backend" v-model="areas.val">
                <label for="backend">Backend Development</label>
            </div>
            <div>
                <input type="checkbox" name="" id="career" value="career" v-model="areas.val">
                <label for="career">Career Advisory</label>
            </div>
        </div>
        <p v-if="!formIsValid">Please Provide the valid details.</p>
        <base-button>Register</base-button>
    </form>
</template>


<script>
export default{
    emits:['save-data'],
    data(){
        return{
            firstName:{
              val:'',
              isValid:true
            },
            lastName:{
              val:'',
              isValid:true
            },
            description:{
              val:'',
              isValid:true
            },
            rate:{
              val:null,
              isValid:true
            },
            areas:{
              val:[],
              isValid:true
            },
            formIsValid:true
        }
        
    },
    methods:{
        formValidate(){
          this.formIsValid=true;

          if(this.firstName.val ===''){
            this.firstName.isValid=false;
            this.formIsValid=false;
          }
          if(this.lastName.val ===''){
            this.lastName.isValid=false;
            this.formIsValid=false;
          }
          if(this.description.val ===''){
            this.description.isValid=false;
            this.formIsValid=false;
          }
          if(this.rate.val ===null || this.rate.val < 0){
            this.rate.isValid=false;
            this.formIsValid=false;
          }
          if(this.areas.val.length === 0){
            this.areas.isValid=false;
            this.formIsValid=false;
          }
        },
        submitForm(){

            this.formValidate();

            if(!this.formIsValid)
              return;
            
            const formData={
                first:this.firstName.val,
                last:this.lastName.val,
                desc:this.description.val,
                rate:this.rate.val,
                areas:this.areas.val
            };
            this.$emit('save-data',formData);
        }
    }
}
</script>

<style scoped>
.form-control {
  margin: 0.5rem 0;
}

label {
  font-weight: bold;
  display: block;
  margin-bottom: 0.5rem;
}

input[type='checkbox'] + label {
  font-weight: normal;
  display: inline;
  margin: 0 0 0 0.5rem;
}

input,
textarea {
  display: block;
  width: 100%;
  border: 1px solid #ccc;
  font: inherit;
}

input:focus,
textarea:focus {
  background-color: #f0e6fd;
  outline: none;
  border-color: #3d008d;
}

input[type='checkbox'] {
  display: inline;
  width: auto;
  border: none;
}

input[type='checkbox']:focus {
  outline: #3d008d solid 1px;
}

h3 {
  margin: 0.5rem 0;
  font-size: 1rem;
}

.invalid label {
  color: red;
}

.invalid input,
.invalid textarea {
  border: 1px solid red;
}
</style>