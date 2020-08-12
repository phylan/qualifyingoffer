<template>
  <div id="app" class="min-h-screen flex items-center justify-center">
    <OfferHero
      :amount="amount"
      />
  </div>
</template>

<script>
import OfferHero from './components/OfferHero'
import { Api } from './api'

export default {
  name: 'App',
  components: {
    OfferHero
  },
  data() {
    return {
      amount: null,

    }
  },
  async created() {
    try {
      let resp = await Api.qualifyingOffers.get()
      this.amount = resp.amount
    }
    catch(err) {

    }
  }
}
</script>

<style src="./assets/tailwind.css">