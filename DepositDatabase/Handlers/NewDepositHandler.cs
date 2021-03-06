﻿using System;
using DepositDatabase.Model;
using DepositState = DomainLogic.Model.DepositState;

namespace DepositDatabase.Handlers
{
    public class NewDepositHandler : DomainLogic.Handlers.INewDepositHandler
    {
        public DomainLogic.Model.Card GetCardById(string id)
        {
            return CardsData.GetCardById(id).ToDomainLogic();
        }

        public DomainLogic.Model.Currency GetCurrencyByDepositTermsId(int termsId)
        {
            return DepositTermsData.GetTermById(termsId).Currency.ToDomainLogic();
        }

        public DomainLogic.Model.Deposit CreateNewDeposit(decimal depositAmount, int wayOfAccumulationId, string userId, int termsId, string cardId)
        {
            var depositTerm = DepositTermsData.GetTermById(termsId);

            var newDeposit = new Deposit()
            {
                UserOwnerId = userId,
                InitialAmount = depositAmount,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(depositTerm.Months),
                Balance = depositAmount,
                DepositWayOfAccumulation = DepositWaysOfAccumulationData.GetWayById(wayOfAccumulationId),
                Card = CardsData.GetCardById(cardId),
                DepositTerm = depositTerm,
                DepositState = DepositStatesData.GetStateByName(DepositState.OpenedDepositStateName)
            };

            DepositsData.AddNewDepositToDbContext(newDeposit);

            return newDeposit.ToDomainLogic();
        }

        public void DecreaseCardBalanceByDepositAmount(decimal depositAmount, string cardId)
        {
            var card = CardsData.GetCardById(cardId);
            card.Balance -= depositAmount;
        }

        public void AddCardHistoryRecord(string cardId, string cardHistoryDescription)
        {
            var card = CardsData.GetCardById(cardId);
            CardHistoryData.AddRecordToDbContext(card, cardHistoryDescription);
        }
    }
}
