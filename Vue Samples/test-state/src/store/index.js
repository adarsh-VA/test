import {createStore} from 'vuex';

import productsModule from './modules/products.js';
import cartModule from './modules/cart.js';

const store = createStore({
    modules:{
        prods:productsModule,
        cart:cartModule
    },
    state(){
        return {
            isLoggedIn: false
        }
    },
    mutations:{
        doLogin(state) {
            state.isLoggedIn = true;
        },
        doLogout(state) {
            state.isLoggedIn = false;
        }
    },
    actions:{
        login(context) {
            context.commit('doLogin');
        },
        logout(context) {
            context.commit('doLogout');
        },
    },
    getters:{
        isAuthenticated(state){
            return state.isLoggedIn;
        }
    }
});

export default store;