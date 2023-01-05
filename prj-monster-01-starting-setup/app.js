
function randomValue(min,max){
    return Math.floor(Math.random() * (max-min) + min)
}

Vue.createApp({
    data(){
        return{
            playerHealth:100,
            monsterHealth:100,
            currentRound:0,
            winner : null,
            logs:[],
            spAttackUsed:false
        }
    },
    watch:{
        playerHealth(value){
            if(value<=0 && this.monsterHealth<=0)
                this.winner = 'draw'
            else if(value<=0)
                this.winner = 'monster'
        },
        monsterHealth(value){
            if(value<=0 && this.playerHealth<=0)
                this.winner = 'draw'
            else if(value<=0)
                this.winner = 'player'
        },
        currentRound(value){
            if(value >=3)
                this.spAttackUsed=false;
        }
    },
    computed:{
        playerBar(){
            if(this.playerHealth <0)
                return {width:'0%'}
            return {width:this.playerHealth + '%'};
        },
        monsterBar(){
            if(this.monsterHealth <0)
                return {width:'0%'}
            return {width:this.monsterHealth + '%'};
        }
    },
    methods:{
        monsterAttack(){
            this.currentRound++;
            var randValue = randomValue(2,8);
            this.monsterHealth -= randValue;
            this.playerAttack();
            this.addLog('player','attack',randValue);
        },
        playerAttack(){
            var randValue = randomValue(5,10);
            this.playerHealth -= randValue;
            this.addLog('monster','attack',randValue);
        },
        specialAttack(){
            this.currentRound=0;
            this.spAttackUsed=true;
            var randValue = randomValue(10,15);
            this.monsterHealth -= randValue;
            this.playerAttack();
            console.log(this.currentRound);
            this.addLog('player','special-attack',randValue);
        },
        heal(){
            var randValue = randomValue(4,10);
            if(this.playerHealth + randValue >100)
                this.playerHealth = 100;
            else
                this.playerHealth+= randValue;
            this.addLog('player','heal',randValue);

        },
        surrender(){
            this.winner = 'monster'
        },
        startAgain(){
            this.winner = null;
            this.currentRound = 0;
            this.playerHealth = 100;
            this.monsterHealth = 100;
            this.logs = []
        },
        addLog(who,what,points){
            this.logs.unshift({
                attackBy:who,
                attackType:what,
                attackPoints:points
            });
        }
    }
}).mount('#game')