<template>
  <v-app>
    <v-app-bar app color="primary" dark>
      <v-toolbar-title class="text-h4 text-uppercase white--text font-weight-light">
        <v-icon large class="white--text">fas fa-file-signature</v-icon>
        Qualifying Offer
      </v-toolbar-title>
      <v-spacer></v-spacer>

    </v-app-bar>

    <v-main>
      <v-container>
        <v-row justify="space-around">
          <v-col cols="auto">
            <OfferHero :amount="qualifyingOfferInfo.amount"/>
          </v-col>
        </v-row>
        <v-row justify="center">
          <v-col cols="12" lg="10">
            <PlayerList 
              :includedPlayers="qualifyingOfferInfo.includedPlayers"
              :excludedPlayers="qualifyingOfferInfo.excludedPlayers"
              :topQuantity="qualifyingOfferInfo.topQuantity"/>
          </v-col>
        </v-row>
      </v-container>
    </v-main>

    <v-footer app>

    </v-footer>
  </v-app>
</template>

<script>
import OfferHero from './components/OfferHero'
import PlayerList from './components/PlayerList'
import { Api } from './api'

export default {
  name: 'App',
  components: {
    OfferHero,
    PlayerList
},
  data() {
    return {
      qualifyingOfferInfo: {
        amount: null,
        topQuantity: null,
        includedPlayers: [],
        excludedPlayers: []
      },
      showDetails: false,
      apiError: false
    }
  },
  async created() {
    try {
      let resp = await Api.qualifyingOffers.get()
      this.qualifyingOfferInfo = { ...resp }
    }
    catch(err) {
      console.log(err)
      this.apiError = true
    }
  }
}
</script>