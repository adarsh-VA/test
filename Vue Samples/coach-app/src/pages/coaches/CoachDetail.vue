<template>
   <div>
        <base-card>
            <h2>{{ fullName }}</h2>
            <h3>${{ selectedCoach.hourlyRate }}/hour</h3>
        </base-card>
   </div>
   <div>
        <base-card>
            <header>
                <h2>Intrested Reach out Now!</h2>
                <base-button link :to="contactLink">Contact</base-button>
            </header>
            <router-view></router-view>
        </base-card>
   </div>
   <div>
    <base-card>
        <base-badge v-for="area in selectedCoach.areas" :key="area" :type="area" :title="area"></base-badge>
        <p>{{ selectedCoach.description }}</p>
    </base-card>
   </div>
</template>

<script>
export default{
    props:['id'],
    data(){
        return{
            selectedCoach : null
        }
    },
    computed:{
        fullName(){
            return this.selectedCoach.firstName+' '+this.selectedCoach.lastName;
        },
        contactLink(){
            return this.$route.path + '/' + this.id + '/contact'
        }
    },
    created(){
        this.selectedCoach = this.$store.getters['coach/coaches'].find(c=>c.id===this.id);
    }
}
</script>