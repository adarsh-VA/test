<template>
    <div>
        <v-app-bar
            elevation="4"
            
        >
            <img src="@/assets/nav-logo.png" alt="" height="40px">
            <v-tabs right color="grey darken-4">
                <v-tabs-slider color="grey darken-4"></v-tabs-slider>
                <v-tab to="/movies">Movies</v-tab>
                <v-tab to="/">Actors</v-tab>
                <v-tab to="/">Producers</v-tab>
            </v-tabs>
        </v-app-bar>
    </div>
</template>