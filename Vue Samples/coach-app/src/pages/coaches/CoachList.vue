<template>
    <coach-filter @change-filter="setFilters"></coach-filter>
    <div>
        <base-card>
        <div class="controls">
            <base-button mode="outline" @click="loadCoaches">Refresh</base-button>
            <base-button to="/register" link>Register as Coach</base-button>
        </div>
        <ul v-if="hasCoaches">
            <coach-item v-for="coach in filterdCoaches" :key="coach.id" 
            :id="coach.id"
            :firstName="coach.firstName"
            :lastName="coach.lastName"
            :rate="coach.hourlyRate"
            :areas="coach.areas"></coach-item>
        </ul>
        <h3 v-else>No Coaches to Display</h3>
        </base-card>
    </div>
</template>

<script>
import CoachItem from '@/components/coaches/CoachItem.vue';
import CoachFilter from '@/components/coaches/CoachFilter.vue'

export default{
    components:{
        CoachItem,
        CoachFilter
    },
    data(){
        return{
            filters:{
                frontend:true,
                backend:true,
                career:true
            }
        }
    },
    computed:{
        hasCoaches(){
            return this.$store.getters['coach/hasCoaches'];
        },
        filterdCoaches(){
            const coaches = this.$store.getters['coach/coaches'];
            return coaches.filter(c=>{
                if(this.filters.frontend && c.areas.includes('frontend'))
                    return true;
                if(this.filters.backend && c.areas.includes('backend'))
                    return true;
                if(this.filters.career && c.areas.includes('career'))
                    return true;
                return false;
            });
        }
    },
    created(){
        this.loadCoaches();
    },
    methods:{
        setFilters(updatedFilters){
            this.filters=updatedFilters;
        },
        async loadCoaches(){
            await this.$store.dispatch('coach/loadCoaches')
        }
    }
}
</script>

<style scoped>
ul {
  list-style: none;
  margin: 0;
  padding: 0;
}

.controls {
  display: flex;
  justify-content: space-between;
}
</style>