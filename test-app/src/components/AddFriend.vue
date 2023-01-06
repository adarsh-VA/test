<template>
    <form action="" @submit.prevent="submitData">
        <div>
            <label for="name">Name:</label>
            <input type="text" id="name" v-model="name" required>
        </div>
        <div>
            <label for="Phone">Phone:</label>
            <input type="number" id="phone" v-model="phoneNumber" required>
        </div>
        <div>
            <label for="email">Email:</label>
            <input type="email" id="email" v-model="email" required>
        </div>
        <button type="submit">Submit</button>
    </form>
</template>

<script>
export default{
    data(){
        return{
            name:'',
            email:'',
            phoneNumber:0
        }
    },
    methods:{
        submitData(){
            this.$emit('add-data',this.name,this.email,this.phoneNumber);
            this.name='';
            this.email='';
            this.phoneNumber='';
        }
    }

};
</script>