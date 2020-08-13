<template>
  <div id="app" class="pt-10 h-screen bg-gray-200">
    <div class="justify-center" v-if="showDetails">
      <PlayerList
        v-bind="qualifyingOfferInfo" />
    </div>
    <div class="flex justify-center">
      <OfferHero
        :amount="qualifyingOfferInfo.amount"
        />
    </div>
    <div class="flex justify-center">
      <button 
        class="rounded-lg px-2 bg-maroon hover:bg-maroon-lighter -mt-3 z-50"
        @click="() => showDetails = !showDetails">
        <div class="text-white uppercase tracking-widest">{{ showDetails ? 'Hide' : 'Show' }} Details</div>
      </button>
    </div>
  </div>
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
      showDetails: false
    }
  },
  async created() {
    try {
      let resp = await Api.qualifyingOffers.get()
      this.qualifyingOfferInfo = { ...resp }
    }
    catch(err) {
      console.log(err)
    }
  }
}
</script>

<style src="./assets/tailwind.css">