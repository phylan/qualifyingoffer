<template>
  <div id="app" class="mt-20 h-screen">
    <div class="flex justify-center" v-if="showDetails">
      <PlayerList
        :players="includedPlayers"/>
    </div>
    <div class="flex justify-center">
      <OfferHero
        :amount="amount"
        />
    </div>
    <div class="flex justify-center">
      <button 
        class="rounded-lg px-2 bg-maroon hover:bg-maroon-lighter -mt-3"
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
      amount: null,
      includedPlayers: [],
      showDetails: false
    }
  },
  async created() {
    try {
      let resp = await Api.qualifyingOffers.get()
      this.amount = resp.amount
      this.includedPlayers = resp.includedPlayers
    }
    catch(err) {
      console.log(err)
    }
  }
}
</script>

<style src="./assets/tailwind.css">