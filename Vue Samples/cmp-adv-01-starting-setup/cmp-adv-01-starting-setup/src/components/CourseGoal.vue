<template>
    <ul>
        <li v-for="goal in goals" :key="goal">
            <slot :item="goal" test-prop="okok"></slot>
        </li>
    </ul>
</template>

<script>
    export default{
        data(){
            return {
                goals:['goal1','goal2']
            }
        }
    }
</script>