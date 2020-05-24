<template>
    <div class="dashboard">
        <span>Almost before we knew it, we had left the ground.</span>
        <div v-if="liveMatches != null && liveMatches.length > 0">
            <div v-bind:key="match.matchId"
                 v-for="match in liveMatches">
                <div>
                    <router-link :to="{ name: 'LiveMatch', params: { serverSteamId: match.serverSteamId }}">
                        {{match.radiant.name}}
                    </router-link>

                    {{match.radiant.lead}}
                    <img :src="match.radiant.logo" width="100" height="100"/>

                </div>
                <div>
                    <router-link :to="{ name: 'LiveMatch', params: { serverSteamId: match.serverSteamId }}">
                        {{match.dire.name}}
                    </router-link>
                    {{match.dire.lead}}
                    <img :src="match.dire.logo" width="100" height="100"/>
                </div>
            </div>
        </div>
    </div>
</template>

<script>

    //import store from "@/store/index"; 
    import {mapState} from "vuex";

    export default {
        components: {},
        data() {
            return {};
        },
        created() {
            this.$store.dispatch('matches/getLiveMatches');
        },
        computed: {
            ...mapState({
                liveMatches: state => state.matches.liveMatches
            })
        },
        methods: {
            navigate(serverSteamId) {
                this.$router.push({
                    name: "LiveMatch",
                    params: {serverSteamId: serverSteamId}
                });
            }
        }
    };
</script>
